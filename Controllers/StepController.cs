using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly StepService _stepService;

        public StepController(StepService stepService)
        {
            _stepService = stepService;
        }

        // POST: api/Step
        [HttpPost]
        public IActionResult CreateStep(StepDto stepDto)
        {
            var createdStepDto = _stepService.CreateStep(stepDto);
            return CreatedAtAction("GetStepById", new { id = createdStepDto.Id }, createdStepDto);
        }

        // GET: api/Step/{id}
        [HttpGet("{id}")]
        public ActionResult<StepDto> GetStepById(int id)
        {
            var stepDto = _stepService.GetStepById(id);

            if (stepDto == null)
            {
                return NotFound();
            }

            return stepDto;
        }

        // GET: api/Step/ByCompetition/{competitionId}
        [HttpGet("ByCompetition/{competitionId}")]
        public ActionResult<IEnumerable<StepDto>> GetStepsByCompetition(int competitionId)
        {
            var stepsDto = _stepService.GetStepsByCompetition(competitionId);
            return stepsDto;
        }
    }
}
