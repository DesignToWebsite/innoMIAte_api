using innomiate_api.DTOs.ValidationSteps;
using innomiate_api.Models.ValidationSteps;
using INNOMIATE_API.Data;
using System;
using System.Linq;

namespace innomiate_api.Services
{
    public class StepTemplateModelService
    {
        private readonly ApplicationDbContext _context;

        public StepTemplateModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StepTemplateModelDto CreateStepTemplateModel(StepTemplateModelDto stepTemplateModelDto)
        {
            try
            {
                var stepTemplateModel = new StepTemplateModel
                {
                    FileName = stepTemplateModelDto.FileName,
                    FilePath = stepTemplateModelDto.FilePath
                };

                _context.StepTemplateModels.Add(stepTemplateModel);
                _context.SaveChanges();

                stepTemplateModelDto.StepTemplateModelId = stepTemplateModel.StepTemplateModelId; // Update ID in DTO
                return stepTemplateModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create StepTemplateModel", ex);
            }
        }

        public StepTemplateModelDto UpdateStepTemplateModel(int id, StepTemplateModelDto stepTemplateModelDto)
        {
            try
            {
                var stepTemplateModel = _context.StepTemplateModels.Find(id);

                if (stepTemplateModel == null)
                    throw new ArgumentException("StepTemplateModel not found");

                stepTemplateModel.FileName = stepTemplateModelDto.FileName;
                stepTemplateModel.FilePath = stepTemplateModelDto.FilePath;

                _context.SaveChanges();

                return stepTemplateModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update StepTemplateModel", ex);
            }
        }

        public void DeleteStepTemplateModel(int id)
        {
            try
            {
                var stepTemplateModel = _context.StepTemplateModels.Find(id);

                if (stepTemplateModel == null)
                    throw new ArgumentException("StepTemplateModel not found");

                _context.StepTemplateModels.Remove(stepTemplateModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete StepTemplateModel", ex);
            }
        }
    }
}
