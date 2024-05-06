using Microsoft.AspNetCore.Mvc;
using innomiate_api.DTOs;
using innomiate_api.Services;

namespace innomiate_api.Controllers
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

        [HttpPost]
        public IActionResult CreateTeam([FromBody] TeamDto teamDto)
        {
            var createdTeam = _teamService.CreateTeam(teamDto);
            return Ok(createdTeam);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, [FromBody] TeamDto teamDto)
        {
            var updatedTeam = _teamService.UpdateTeam(id, teamDto);
            return Ok(updatedTeam);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            _teamService.DeleteTeam(id);
            return Ok();
        }

        [HttpGet("by-competition/{competitionId}")]
        public IActionResult GetTeamsByCompetitionId(int competitionId)
        {
            try
            {
                var teams = _teamService.GetTeamsByCompetitionId(competitionId);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
