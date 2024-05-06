using innomiate_api.DTOs.Submission;
using innomiate_api.Models.Submission;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{
    public class SubmissionModelService
    {
        private readonly ApplicationDbContext _context;

        public SubmissionModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public SubmissionModelDto CreateSubmissionModel(SubmissionModelDto submissionModelDto)
        {
            try
            {
                var submissionModel = new SubmissionModel
                {
                    Title = submissionModelDto.Title,
                    Description = submissionModelDto.Description,
                    CompetitionId = submissionModelDto.CompetitionId
                };

                _context.SubmissionModels.Add(submissionModel);
                _context.SaveChanges();

                submissionModelDto.SubmissionModelId = submissionModel.SubmissionModelId;
                return submissionModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create submission model", ex);
            }
        }


        public SubmissionModelDto GetSubmissionModelById(int id)
        {
            var submissionModel = _context.SubmissionModels.Find(id);

            if (submissionModel == null)
            {
                throw new ArgumentException("Submission model not found");
            }

            return new SubmissionModelDto
            {
                SubmissionModelId = submissionModel.SubmissionModelId,
                Title = submissionModel.Title,
                Description = submissionModel.Description,
                CompetitionId = submissionModel.CompetitionId
            };
        }

        public SubmissionModelDto UpdateSubmissionModel(int id, SubmissionModelDto submissionModelDto)
        {
            try
            {
                var submissionModel = _context.SubmissionModels.Find(id);

                if (submissionModel == null)
                {
                    throw new ArgumentException("Submission model not found");
                }

                submissionModel.Title = submissionModelDto.Title;
                submissionModel.Description = submissionModelDto.Description;
                submissionModel.CompetitionId = submissionModelDto.CompetitionId;

                _context.SaveChanges();

                return submissionModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update submission model", ex);
            }
        }

        public void DeleteSubmissionModel(int id)
        {
            try
            {
                var submissionModel = _context.SubmissionModels.Find(id);

                if (submissionModel == null)
                {
                    throw new ArgumentException("Submission model not found");
                }

                _context.SubmissionModels.Remove(submissionModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete submission model", ex);
            }
        }

        public List<SubmissionModelDto> GetSubmissionModelsByCompetitionId(int competitionId)
        {
            var submissionModels = _context.SubmissionModels
                .Where(sm => sm.CompetitionId == competitionId)
                .Select(sm => new SubmissionModelDto
                {
                    SubmissionModelId = sm.SubmissionModelId,
                    Title = sm.Title,
                    Description = sm.Description,
                    CompetitionId = sm.CompetitionId
                })
                .ToList();

            return submissionModels;
        }
    }
}
