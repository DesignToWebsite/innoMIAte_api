using System;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachingManagingController : ControllerBase
    {
        private readonly CoachingManagingService _coachingManagingService;

        public CoachingManagingController(CoachingManagingService coachingManagingService)
        {
            _coachingManagingService = coachingManagingService;
        }

        [HttpPost("CreatePendingCoach")]
        public async Task<ActionResult<CompetitionPendingCoachDto>> CreatePendingCoach(CompetitionPendingCoachDto coachDto)
        {
            try
            {
                var createdCoach = await _coachingManagingService.CreatePendingCoach(coachDto);
                return CreatedAtAction(nameof(CreatePendingCoach), createdCoach);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePendingCoach/{id}")]
        public async Task<IActionResult> UpdatePendingCoach(int id, CompetitionPendingCoachDto coachDto)
        {
            try
            {
                await _coachingManagingService.UpdatePendingCoach(id, coachDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePendingCoach/{id}")]
        public async Task<IActionResult> DeletePendingCoach(int id)
        {
            try
            {
                await _coachingManagingService.DeletePendingCoach(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAllPendingCoachesByCompetitionId/{competitionId}")]
        public async Task<IActionResult> DeleteAllPendingCoachesByCompetitionId(int competitionId)
        {
            try
            {
                await _coachingManagingService.DeleteAllPendingCoachesByCompetitionId(competitionId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPendingCoachesByCompetitionId/{competitionId}")]
        public ActionResult<List<CompetitionPendingCoachDto>> GetPendingCoachesByCompetitionId(int competitionId)
        {
            try
            {
                var coaches = _coachingManagingService.GetPendingCoachesByCompetitionId(competitionId);
                return coaches;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoints for managing coaching announcements
        [HttpPost("CreateAnnouncement")]
        public async Task<ActionResult<CompetitionCoachingAnnounceDto>> CreateAnnouncement(CompetitionCoachingAnnounceDto announceDto)
        {
            try
            {
                var createdAnnouncement = await _coachingManagingService.CreateAnnouncement(announceDto);
                return CreatedAtAction(nameof(CreateAnnouncement), createdAnnouncement);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAnnouncement/{id}")]
        public async Task<IActionResult> UpdateAnnouncement(int id, CompetitionCoachingAnnounceDto announceDto)
        {
            try
            {
                await _coachingManagingService.UpdateAnnouncement(id, announceDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAnnouncement/{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            try
            {
                await _coachingManagingService.DeleteAnnouncement(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAnnouncementsByCompetitionId/{competitionId}")]
        public ActionResult<CompetitionCoachingAnnounceDto> GetAnnouncementsByCompetitionId(int competitionId)
        {
            try
            {
                var announcement = _coachingManagingService.GetAnnouncementByCompetitionId(competitionId);
                return announcement;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Managing Tags 
        [HttpPost("CreateTag")]
        public async Task<ActionResult<CompetitionCoachingTagDto>> CreateTag(CompetitionCoachingTagDto tagDto)
        {
            try
            {
                var createdTag = await _coachingManagingService.CreateTag(tagDto);
                return CreatedAtAction(nameof(CreateTag), createdTag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateTag/{id}")]
        public async Task<IActionResult> UpdateTag(int id, CompetitionCoachingTagDto tagDto)
        {
            try
            {
                await _coachingManagingService.UpdateTag(id, tagDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteTag/{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            try
            {
                await _coachingManagingService.DeleteTag(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTagsByCompetitionId/{competitionId}")]
        public ActionResult<List<CompetitionCoachingTagDto>> GetTagsByCompetitionId(int competitionId)
        {
            try
            {
                var tags = _coachingManagingService.GetTagsByCompetitionId(competitionId);
                return tags;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
