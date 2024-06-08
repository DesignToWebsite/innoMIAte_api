using Microsoft.AspNetCore.Mvc;

using innomiate_api.DTOs;
using innomiate_api.Services.INNOMIATE_API.Services;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantService _participantService;

        public ParticipantController(ParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateParticipant([FromBody] CreateParticipantDto createParticipantDto)
        {
            var createdParticipant = await _participantService.CreateParticipantAsync(createParticipantDto);
            return Ok(createdParticipant);
        }

        [HttpDelete("delete/{participantId}")]
        public async Task<IActionResult> DeleteParticipant(int participantId)
        {
            var result = await _participantService.DeleteParticipantAsync(participantId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        /*
        [HttpPut("update/team")]
        public async Task<IActionResult> UpdateParticipantTeam([FromBody] UpdateParticipantTeamDto updateParticipantTeamDto)
        {
            var updatedParticipant = await _participantService.UpdateParticipantTeamAsync(updateParticipantTeamDto);
            if (updatedParticipant == null)
            {
                return NotFound();
            }
            return Ok(updatedParticipant);
        } */

        [HttpPut("update")]
        public async Task<IActionResult> UpdateParticipant([FromBody] UpdateParticipantDto updateParticipantDto)
        {
            var updatedParticipant = await _participantService.UpdateParticipantAsync(updateParticipantDto);
            if (updatedParticipant == null)
            {
                return NotFound();
            }
            return Ok(updatedParticipant);
        }
    }
}
