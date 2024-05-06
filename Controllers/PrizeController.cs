using Microsoft.AspNetCore.Mvc;
using innomiate_api.DTOs.Prizing;
using innomiate_api.Models.Prizing;
using innomiate_api.Services;
using Microsoft.EntityFrameworkCore;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly PrizeService _prizeService;

        public PrizeController(PrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        // GET: api/Prize/{prizeId}
        [HttpGet("Prize/{prizeId}")]
        public ActionResult<PrizeDto> GetPrize(int prizeId)
        {
            var prizeDto = _prizeService.GetPrize(prizeId);
            if (prizeDto == null)
            {
                return NotFound();
            }
            return prizeDto;
        }

        // POST: api/Prize
        [HttpPost("Prize")]
        public ActionResult<Prize> PostPrize(PrizeDto prizeDto)
        {
            var createdPrize = _prizeService.CreatePrize(prizeDto);
            return CreatedAtAction(nameof(GetPrize), new { prizeId = createdPrize.PrizeId }, createdPrize);
        }

        // PUT: api/Prize/{prizeId}
        [HttpPut("Prize/{prizeId}")]
        public IActionResult PutPrize(int prizeId, PrizeDto prizeDto)
        {
            if (prizeId != prizeDto.PrizeId)
            {
                return BadRequest();
            }
            _prizeService.UpdatePrize(prizeDto);
            return NoContent();
        }

        // DELETE: api/Prize/{prizeId}
        [HttpDelete("Prize/{prizeId}")]
        public ActionResult<Prize> DeletePrize(int prizeId)
        {
            var prize = _prizeService.DeletePrize(prizeId);
            if (prize == null)
            {
                return NotFound();
            }
            return prize;
        }

        // GET: api/Prize/Prizing/{competitionId}
        [HttpGet("Prizing/{competitionId}")]
        public ActionResult<PrizingDto> GetPrizing(int competitionId)
        {
            var prizingDto = _prizeService.GetPrizing(competitionId);
            if (prizingDto == null)
            {
                return NotFound();
            }
            return prizingDto;
        }

        // POST: api/Prize/Prizing
        [HttpPost("Prizing")]
        public ActionResult<Prizing> PostPrizing(PrizingDto prizingDto)
        {
            var createdPrizing = _prizeService.CreatePrizing(prizingDto);
            return CreatedAtAction(nameof(GetPrizing), new { competitionId = createdPrizing.CompetitionId }, createdPrizing);
        }

        // PUT: api/Prize/Prizing/{competitionId}
        [HttpPut("Prizing/{competitionId}")]
        public IActionResult PutPrizing(int competitionId, PrizingDto prizingDto)
        {
            if (competitionId != prizingDto.CompetitionId)
            {
                return BadRequest();
            }
            _prizeService.UpdatePrizing(prizingDto);
            return NoContent();
        }

        // DELETE: api/Prize/Prizing/{competitionId}
        [HttpDelete("Prizing/{competitionId}")]
        public ActionResult<Prizing> DeletePrizing(int competitionId)
        {
            var prizing = _prizeService.DeletePrizing(competitionId);
            if (prizing == null)
            {
                return NotFound();
            }
            return prizing;
        }
    }
}
