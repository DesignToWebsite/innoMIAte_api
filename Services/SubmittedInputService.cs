using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INNOMIATE_API.Services
{
    public class SubmittedInputService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SubmittedInputService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void CreateSubmittedInputs(SubmittedInputCreateDto createDto)
        {
            var step = _context.StepCompetitions
                .Include(s => s.ToComplete)
                .FirstOrDefault(s => s.IdSteps == createDto.StepId);

            if (step == null)
            {
                throw new ArgumentException("Step not found.");
            }

            if (createDto.Values.Count != step.ToComplete.Count)
            {
                throw new ArgumentException("Number of input values does not match number of step inputs.");
            }

            var group = _context.Groups.FirstOrDefault(g => g.GroupId == createDto.GroupId);
            if (group == null)
            {
                throw new ArgumentException("Group not found.");
            }

            for (int i = 0; i < step.ToComplete.Count; i++)
            {
                var value = createDto.Values[i];

                var submittedInput = new SubmittedInput
                {
                    StepInputId = step.ToComplete[i].Id,
                    GroupId = group.GroupId,
                    Value = SaveFile(value)
                };

                _context.SubmittedInputs.Add(submittedInput);
            }

            _context.SaveChanges();
        }

        public List<SubmittedInputDto> GetSubmittedInputsByGroupId(int groupId)
        {
            var submittedInputs = _context.SubmittedInputs
                .Where(si => si.GroupId == groupId)
                .Select(si => new SubmittedInputDto
                {
                    Id = si.Id,
                    StepInputId = si.StepInputId,
                    TeamId= si.GroupId,
                    Value = si.Value
                })
                .ToList();

            return submittedInputs;
        }

        public void DeleteSubmittedInputs(int groupId, int stepId)
        {
            var submittedInputs = _context.SubmittedInputs
                .Where(si => si.GroupId == groupId && si.StepInput.StepCompetition.IdSteps == stepId)
                .ToList();

            _context.SubmittedInputs.RemoveRange(submittedInputs);
            _context.SaveChanges();
        }

        private string SaveFile(IFormFile file)
        {
            var uploadsDirectory = Path.Combine(_environment.ContentRootPath, "uploads");

            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }
    }
}
