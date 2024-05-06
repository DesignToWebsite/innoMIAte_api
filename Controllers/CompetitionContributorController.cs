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
    public class CompetitionContributorController : ControllerBase
    {
        private readonly CompetitionContributorService _contributorService;

        public CompetitionContributorController(CompetitionContributorService contributorService)
        {
            _contributorService = contributorService;
        }

        [HttpPost]
        public async Task<ActionResult<CompetitionContributorDto>> CreateContributor(CompetitionContributorDto contributorDto)
        {
            try
            {
                var createdContributor = await _contributorService.CreateContributor(contributorDto);
                return CreatedAtAction(nameof(CreateContributor), createdContributor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContributor(int id, CompetitionContributorDto contributorDto)
        {
            try
            {
                await _contributorService.UpdateContributor(id, contributorDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContributor(int id)
        {
            try
            {
                await _contributorService.DeleteContributor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{competitionId}")]
        public ActionResult<List<CompetitionContributorDto>> GetContributorsByCompetitionId(int competitionId)
        {
            try
            {
                var contributors = _contributorService.GetContributorsByCompetitionId(competitionId);
                return contributors;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
