using System.Collections.Generic;
using System.Linq;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace INNOMIATE_API.Services
{
    public class StepService
    {
        private readonly ApplicationDbContext _context;

        public StepService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StepDto CreateStep(StepDto stepDto)
        {
            var step = new StepCompetition
            {
                IdCompetition = stepDto.CompetitionId,
                Title = stepDto.Title,
                Description = stepDto.Description,
                SecondTitle = stepDto.SecondTitle,
                StepOpen = stepDto.StepOpen,
                DeadLineEnd = stepDto.DeadLineEnd,
                ToComplete = stepDto.ToComplete?.Select(si => new StepInput
                {
                    Type = si.Type,
                    Tag = si.Tag,
                    Label = si.Label,
                    Placeholder = si.Placeholder,
                    IdName = si.IdName,
                    MaxCaracter = si.MaxCaracter,
                    Description = si.Description
                }).ToList()
            };

            _context.StepCompetitions.Add(step);
            _context.SaveChanges();

            stepDto.Id = step.IdSteps;
            return stepDto;
        }

        public StepDto GetStepById(int id)
        {
            var step = _context.StepCompetitions
                .Include(s => s.ToComplete)
                .SingleOrDefault(s => s.IdSteps == id);

            if (step == null)
            {
                return null;
            }

            var stepDto = new StepDto
            {
                Id = step.IdSteps,
                CompetitionId = step.IdCompetition,
                Title = step.Title,
                Description = step.Description,
                SecondTitle = step.SecondTitle,
                StepOpen = step.StepOpen,
                DeadLineEnd = step.DeadLineEnd,
                ToComplete = step.ToComplete?.Select(si => new StepInputDto
                {
                    Id = si.Id,
                    StepId = si.StepCompetitionId,
                    Type = si.Type,
                    Tag = si.Tag,
                    Label = si.Label,
                    Placeholder = si.Placeholder,
                    IdName = si.IdName,
                    MaxCaracter = si.MaxCaracter,
                    Description = si.Description
                }).ToList()
            };

            return stepDto;
        }

        public List<StepDto> GetStepsByCompetition(int competitionId)
        {
            var steps = _context.StepCompetitions
                .Include(s => s.ToComplete)
                .Where(s => s.IdCompetition == competitionId)
                .Select(s => new StepDto
                {
                    Id = s.IdSteps,
                    CompetitionId = s.IdCompetition,
                    Title = s.Title,
                    Description = s.Description,
                    SecondTitle = s.SecondTitle,
                    StepOpen = s.StepOpen,
                    DeadLineEnd = s.DeadLineEnd,
                    ToComplete = s.ToComplete.Select(si => new StepInputDto
                    {
                        Id = si.Id,
                        StepId = si.StepCompetitionId,
                        Type = si.Type,
                        Tag = si.Tag,
                        Label = si.Label,
                        Placeholder = si.Placeholder,
                        IdName = si.IdName,
                        MaxCaracter = si.MaxCaracter,
                        Description = si.Description
                    }).ToList()
                })
                .ToList();

            return steps;
        }
    }
}
