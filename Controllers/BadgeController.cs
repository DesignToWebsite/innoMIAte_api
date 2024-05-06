using Microsoft.AspNetCore.Mvc;
using innomiate_api.DTOs.Badging;
using innomiate_api.Models.Badging;
using innomiate_api.Services;
using Microsoft.EntityFrameworkCore;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly BadgeService _badgeService;

        public BadgeController(BadgeService badgeService)
        {
            _badgeService = badgeService;
        }

        // GET: api/Badge/{badgeId}
        [HttpGet("{badgeId}")]
        public ActionResult<BadgeDto> GetBadge(int badgeId)
        {
            var badgeDto = _badgeService.GetBadge(badgeId);
            if (badgeDto == null)
            {
                return NotFound();
            }
            return badgeDto;
        }

        // POST: api/Badge
        [HttpPost]
        public ActionResult<Badge> PostBadge(BadgeDto badgeDto)
        {
            var createdBadge = _badgeService.CreateBadge(badgeDto);
            return CreatedAtAction(nameof(GetBadge), new { badgeId = createdBadge.BadgeId }, createdBadge);
        }

        // PUT: api/Badge/{badgeId}
        [HttpPut("{badgeId}")]
        public IActionResult PutBadge(int badgeId, BadgeDto badgeDto)
        {
            if (badgeId != badgeDto.BadgeId)
            {
                return BadRequest();
            }
            _badgeService.UpdateBadge(badgeDto);
            return NoContent();
        }

        // DELETE: api/Badge/{badgeId}
        [HttpDelete("{badgeId}")]
        public ActionResult<Badge> DeleteBadge(int badgeId)
        {
            var badge = _badgeService.DeleteBadge(badgeId);
            if (badge == null)
            {
                return NotFound();
            }
            return badge;
        }

        // GET: api/Badge/Badging/{competitionId}
        [HttpGet("Badging/{competitionId}")]
        public ActionResult<BadgingDto> GetBadging(int competitionId)
        {
            var badgingDto = _badgeService.GetBadging(competitionId);
            if (badgingDto == null)
            {
                return NotFound();
            }
            return badgingDto;
        }

        // POST: api/Badge/Badging
        [HttpPost("Badging")]
        public ActionResult<Badging> PostBadging(BadgingDto badgingDto)
        {
            var createdBadging = _badgeService.CreateBadging(badgingDto);
            return CreatedAtAction(nameof(GetBadging), new { competitionId = createdBadging.CompetitionId }, createdBadging);
        }

        // PUT: api/Badge/Badging/{competitionId}
        [HttpPut("Badging/{competitionId}")]
        public IActionResult PutBadging(int competitionId, BadgingDto badgingDto)
        {
            if (competitionId != badgingDto.CompetitionId)
            {
                return BadRequest();
            }
            _badgeService.UpdateBadging(badgingDto);
            return NoContent();
        }

        // DELETE: api/Badge/Badging/{competitionId}
        [HttpDelete("Badging/{competitionId}")]
        public ActionResult<Badging> DeleteBadging(int competitionId)
        {
            var badging = _badgeService.DeleteBadging(competitionId);
            if (badging == null)
            {
                return NotFound();
            }
            return badging;
        }
    }
}
