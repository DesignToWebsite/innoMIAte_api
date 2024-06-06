using System.Collections.Generic;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
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

        [HttpPost("create-step-with-inputs")]
        public async Task<IActionResult> CreateStepWithInputs([FromBody] StepWithInputsDto stepWithInputsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _stepsService.CreateStepWithInputsAsync(stepWithInputsDto);
            return Ok(result);
        }
    }
}
