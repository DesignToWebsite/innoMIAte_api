using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using innomiate_api.DTOs;

namespace INNOMIATE_API.Controllers 

{
    [ApiController]
    [Route("api/[controller]")]
    public class StepCompetitionController : ControllerBase
    {
        private readonly StepCompetitionService _StepCompetitionService;

        public StepCompetitionController(StepCompetitionService stepCompetitionService)
        {
            _StepCompetitionService = stepCompetitionService;
        }

        [HttpGet("competitionSteps/{competitionId}")]
        public async Task<IActionResult> GetAllStepsCompetitions(int competitionId)
        {
            var StepsCompetition = await _StepCompetitionService
                        .GetAllStepsCompetitions(competitionId);
            return Ok(StepsCompetition);
        }

        [HttpGet("step/{id}")]
        public async Task<IActionResult> GetStepById(int id)
        {
            var step = await _StepCompetitionService.GetStepById(id);
            if (step == null)
            {
                return NotFound();
            }
            return Ok(step);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStep(StepCompetitionDto stepCompetitionDto)
        {
            var createdStepComp = await _StepCompetitionService.CreateStep(stepCompetitionDto);
            return CreatedAtAction
            (nameof(GetStepById), 
            new { id = createdStepComp.IdSteps }, createdStepComp);
        }

        
    }


}
