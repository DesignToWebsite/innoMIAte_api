using Microsoft.AspNetCore.Mvc;

using INNOMIATE_API.Services;
using innomiate_api.DTOs;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto createTeamDto)
        {
            var createdTeam = await _teamService.CreateTeamAsync(createTeamDto);
            return Ok(createdTeam);
        }

        [HttpDelete("delete/{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var result = await _teamService.DeleteTeamAsync(teamId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamDto updateTeamDto)
        {
            var updatedTeam = await _teamService.UpdateTeamAsync(updateTeamDto);
            if (updatedTeam == null)
            {
                return NotFound();
            }
            return Ok(updatedTeam);
        }

        [HttpGet("get/{teamId}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            var team = await _teamService.GetTeamByIdAsync(teamId);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
