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
    public class CompetitionSponsorController : ControllerBase
    {
        private readonly CompetitionSponsorService _sponsorService;

        public CompetitionSponsorController(CompetitionSponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpPost]
        public async Task<ActionResult<CompetitionSponsorDto>> CreateSponsor(CompetitionSponsorDto sponsorDto)
        {
            try
            {
                var createdSponsor = await _sponsorService.CreateSponsor(sponsorDto);
                return CreatedAtAction(nameof(CreateSponsor), createdSponsor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSponsor(int id, CompetitionSponsorDto sponsorDto)
        {
            try
            {
                await _sponsorService.UpdateSponsor(id, sponsorDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSponsor(int id)
        {
            try
            {
                await _sponsorService.DeleteSponsor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{competitionId}")]
        public ActionResult<List<CompetitionSponsorDto>> GetSponsorsByCompetitionId(int competitionId)
        {
            try
            {
                var sponsors = _sponsorService.GetSponsorsByCompetitionId(competitionId);
                return sponsors;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
