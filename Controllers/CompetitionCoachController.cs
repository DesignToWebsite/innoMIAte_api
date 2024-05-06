using System;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using INNOMIATE_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionCoachController : ControllerBase
    {
        private readonly CompetitionCoachService _coachService;

        public CompetitionCoachController(CompetitionCoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpPost]
        public async Task<ActionResult<CompetitionCoachDto>> CreateCoach(CompetitionCoachDto coachDto)
        {
            try
            {
                var createdCoach = await _coachService.CreateCoach(coachDto);
                return CreatedAtAction(nameof(CreateCoach), createdCoach);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(int id, CompetitionCoachDto coachDto)
        {
            try
            {
                await _coachService.UpdateCoach(id, coachDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            try
            {
                await _coachService.DeleteCoach(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{competitionId}")]
        public ActionResult<List<CompetitionCoachDto>> GetCoachesByCompetitionId(int competitionId)
        {
            try
            {
                var coaches = _coachService.GetCoachesByCompetitionId(competitionId);
                return coaches;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
