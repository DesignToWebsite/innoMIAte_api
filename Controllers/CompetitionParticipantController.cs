using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using INNOMIATE_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionParticipantController : ControllerBase
    {
        private readonly CompetitionParticipantService _participantService;

        public CompetitionParticipantController(CompetitionParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<ActionResult<CompetitionParticipantDto>> CreateParticipant(CompetitionParticipantDto participantDto)
        {
            try
            {
                var createdParticipant = await _participantService.CreateParticipant(participantDto);
                return CreatedAtAction(nameof(CreateParticipant), createdParticipant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, CompetitionParticipantDto participantDto)
        {
            try
            {
                await _participantService.UpdateParticipant(id, participantDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            try
            {
                await _participantService.DeleteParticipant(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{competitionId}")]
        public ActionResult<List<CompetitionParticipantDto>> GetParticipantsByCompetitionId(int competitionId)
        {
            try
            {
                var participants = _participantService.GetParticipantsByCompetitionId(competitionId);
                return participants;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    /*    [HttpPost("createTeamAssignLeader")]
        public async Task<IActionResult> CreateTeamAndAssignLeader(int participantId, [FromBody] TeamDto teamDto)
        {
            try
            {
                await _participantService.CreateTeamAndAssignLeader(participantId, teamDto);
                return Ok(new {message = "Team created and participant assigned as leader successfully."});
            }
            catch(Exception ex)
            {
                return BadRequest(new {ùessage = ex.Message});
            }
        }*/
    
    }
}
