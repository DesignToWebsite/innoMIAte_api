using innomiate_api.DTOs.ValidationSteps;
using innomiate_api.Models.ValidationSteps;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{
    public class StepModelService
    {
        private readonly ApplicationDbContext _context;

        public StepModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StepModelDto CreateStepModel(StepModelDto stepModelDto)
        {
            try
            {
                var stepModel = new StepModel
                {
                    Title = stepModelDto.Title,
                    Description = stepModelDto.Description,
                    SubmissionType = stepModelDto.SubmissionType,
                    CompetitionId = stepModelDto.CompetitionId,
                    // Assuming StepTemplates will be added separately
                };

                _context.StepModels.Add(stepModel);
                _context.SaveChanges();

                stepModelDto.StepModelId = stepModel.StepModelId; // Update ID in DTO
                return stepModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create StepModel", ex);
            }
        }

        public StepModelDto UpdateStepModel(int id, StepModelDto stepModelDto)
        {
            try
            {
                var stepModel = _context.StepModels.Find(id);

                if (stepModel == null)
                    throw new ArgumentException("StepModel not found");

                stepModel.Title = stepModelDto.Title;
                stepModel.Description = stepModelDto.Description;
                stepModel.SubmissionType = stepModelDto.SubmissionType;
                stepModel.CompetitionId = stepModelDto.CompetitionId;

                _context.SaveChanges();

                return stepModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update StepModel", ex);
            }
        }

        public void DeleteStepModel(int id)
        {
            try
            {
                var stepModel = _context.StepModels.Find(id);

                if (stepModel == null)
                    throw new ArgumentException("StepModel not found");

                _context.StepModels.Remove(stepModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete StepModel", ex);
            }
        }

        public StepModelDto GetStepModelById(int id)
        {
            try
            {
                var stepModel = _context.StepModels
                    .Include(s => s.StepTemplates)
                    .SingleOrDefault(s => s.StepModelId == id);

                if (stepModel == null)
                    throw new ArgumentException("StepModel not found");

                var stepModelDto = new StepModelDto
                {
                    StepModelId = stepModel.StepModelId,
                    Title = stepModel.Title,
                    Description = stepModel.Description,
                    SubmissionType = stepModel.SubmissionType,
                    CompetitionId = stepModel.CompetitionId,
                    StepTemplates = stepModel.StepTemplates.Select(st => new StepTemplateModelDto
                    {
                        StepTemplateModelId = st.StepTemplateModelId,
                        FileName = st.FileName,
                        FilePath = st.FilePath
                    }).ToList()
                };

                return stepModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get StepModel by ID", ex);
            }
        }

        public List<StepModelDto> GetStepModelsByCompetitionId(int competitionId)
        {
            try
            {
                var stepModels = _context.StepModels
                    .Include(s => s.StepTemplates)
                    .Where(s => s.CompetitionId == competitionId)
                    .ToList();

                var stepModelDtos = stepModels.Select(s => new StepModelDto
                {
                    StepModelId = s.StepModelId,
                    Title = s.Title,
                    Description = s.Description,
                    SubmissionType = s.SubmissionType,
                    CompetitionId = s.CompetitionId,
                    StepTemplates = s.StepTemplates.Select(st => new StepTemplateModelDto
                    {
                        StepTemplateModelId = st.StepTemplateModelId,
                        FileName = st.FileName,
                        FilePath = st.FilePath
                    }).ToList()
                }).ToList();

                return stepModelDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get StepModels by competition ID", ex);
            }
        }
    }
}
