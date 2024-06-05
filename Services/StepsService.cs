using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;
using innomiate_api.DTOs;
using INNOMIATE_API.DTOs;
using innomiate_api.Models;

namespace INNOMIATE_API.Services
{
    public class StepsService
    {
        private readonly ApplicationDbContext _context;

        public StepsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StepCompetition> CreateStepAsync(StepCompetitionDto stepDto)
        {
            var step = new StepCompetition
            {
                IdCompetition = stepDto.IdCompetition,
                Title = stepDto.Title,
                Description = stepDto.Description,
                SecondTitle = stepDto.SecondTitle,
                StepOpen = stepDto.StepOpen,
                DeadLineEnd = stepDto.DeadLineEnd
            };

            _context.stepCompetitions.Add(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<StepInput> CreateStepInputAsync(StepInputDto inputDto)
        {
            var stepInput = new StepInput
            {
                Type = inputDto.Type,
                Tag = inputDto.Tag,
                Label = inputDto.Label,
                Placeholder = inputDto.Placeholder,
                IdName = inputDto.IdName,
                MaxCaracter = inputDto.MaxCaracter,
                Description = inputDto.Description
            };

            _context.stepInputs.Add(stepInput);
            await _context.SaveChangesAsync();
            return stepInput;
        }

        public async Task<StepCompetition> CreateStepWithInputsAsync(StepCompetitionDto stepCompetitionDto)
        {
            var step = new StepCompetition
            {
                IdCompetition = stepCompetitionDto.IdCompetition,
                Title = stepCompetitionDto.Title,
                Description = stepCompetitionDto.Description,
                SecondTitle = stepCompetitionDto.SecondTitle,
                StepOpen = stepCompetitionDto.StepOpen,
                DeadLineEnd = stepCompetitionDto.DeadLineEnd,
                ToComplete = stepCompetitionDto.ToComplete,
            };

            _context.stepCompetitions.Add(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<List<StepCompetition>> GetStepsByCompetitionIdAsync(int competitionId)
        {
            return await _context.stepCompetitions
                .Where(sc => sc.IdCompetition == competitionId)
                .Include(sc => sc.ToComplete)
                .ToListAsync();
        }
    }
}
