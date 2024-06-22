using innomiate_api.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittedInputController : ControllerBase
    {
        private readonly SubmittedInputService _submittedInputService;

        public SubmittedInputController(SubmittedInputService submittedInputService)
        {
            _submittedInputService = submittedInputService;
        }

        [HttpPost]
        public IActionResult CreateSubmittedInputs([FromForm] SubmittedInputCreateDto createDto)
        {
            try
            {
                _submittedInputService.CreateSubmittedInputs(createDto);
                return Ok("Submitted inputs created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating submitted inputs: {ex.Message}");
            }
        }

        [HttpGet("group/{groupId}")]
        public IActionResult GetSubmittedInputsByGroupId(int groupId)
        {
            try
            {
                var submittedInputs = _submittedInputService.GetSubmittedInputsByGroupId(groupId);
                return Ok(submittedInputs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving submitted inputs: {ex.Message}");
            }
        }

        [HttpDelete("group/{groupId}/step/{stepId}")]
        public IActionResult DeleteSubmittedInputs(int groupId, int stepId)
        {
            try
            {
                _submittedInputService.DeleteSubmittedInputs(groupId, stepId);
                return Ok("Submitted inputs deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting submitted inputs: {ex.Message}");
            }
        }
    }
}
