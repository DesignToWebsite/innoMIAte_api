using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using innomiate_api.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using innomiate_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace INNOMIATE_API.Services
{/*
    public class StepsService
    {
        private readonly ApplicationDbContext _context;

        public StepsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StepCompetition> CreateStepWithInputsAsync(StepWithInputsDto stepWithInputsDto)
        {
            var step = new StepCompetition
            {
                IdCompetition = stepWithInputsDto.Step.IdCompetition,
                Title = stepWithInputsDto.Step.Title,
                Description = stepWithInputsDto.Step.Description,
                SecondTitle = stepWithInputsDto.Step.SecondTitle,
                StepOpen = stepWithInputsDto.Step.StepOpen,
                DeadLineEnd = stepWithInputsDto.Step.DeadLineEnd
            };

            _context.stepCompetitions.Add(step);
            await _context.SaveChangesAsync();

            foreach (var inputDto in stepWithInputsDto.Inputs)
            {
                var stepInput = new StepInput
                {
                    Type = inputDto.Type,
                    Tag = inputDto.Tag,
                    Label = inputDto.Label,
                    Placeholder = inputDto.Placeholder,
                    IdName = inputDto.IdName,
                    MaxCaracter = inputDto.MaxCaracter,
                    Description = inputDto.Description,
                    StepCompetitionId = step.IdSteps
                };

                _context.stepInputs.Add(stepInput);
            }

            await _context.SaveChangesAsync();
            return step;
        }
    
        public async Task<IEnumerable<StepCompetition>> GetSteps(int idCompetition)
        {
            return await _context.stepCompetitions
                    .Include(s=>s.ToComplete)
                    .Where(s=> s.IdCompetition == idCompetition)
                    .ToListAsync();;
            
            
        }
    
    
    }
    */
}
