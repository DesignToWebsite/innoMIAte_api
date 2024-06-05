using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly StepsService _stepsService;

        public StepsController(StepsService stepsService)
        {
            _stepsService = stepsService;
        }

        [HttpPost("create-step-input")]
        public async Task<IActionResult> CreateStepInput([FromForm] StepInputDto stepInputDto)
        {
            var result = await _stepsService.CreateStepInputAsync(stepInputDto);
            return Ok(result);
        }

        [HttpPost("create-step")]
        public async Task<IActionResult> CreateStep([FromForm] StepCompetitionDto stepCompetitionDto)
        {
            var result = await _stepsService.CreateStepAsync(stepCompetitionDto);
            return Ok(result);
        }
        //CreateStepWithInputsAsync
        [HttpPost("create-step-with-input")]
        public async Task<IActionResult> CreateStepWithInput([FromForm] StepCompetitionDto stepCompetitionDto)
        {
            var result = await _stepsService.CreateStepWithInputsAsync(stepCompetitionDto);
            return Ok(result);
        }
    }
}
