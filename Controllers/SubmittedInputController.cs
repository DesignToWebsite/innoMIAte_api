using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using innomiate_api.Services.innomiate_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittedInputsController : ControllerBase
    {
        private readonly SubmittedInputService _submittedInputService;

        public SubmittedInputsController(SubmittedInputService submittedInputService)
        {
            _submittedInputService = submittedInputService;
        }

        [HttpPost("create-submitted-input")]
        public async Task<IActionResult> CreateSubmittedInput([FromForm] SubmittedInputDto submittedInputDto)
        {
            var result = await _submittedInputService.CreateSubmittedInputAsync(submittedInputDto);
            return Ok(result);
        }
    }
}
