using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompetitionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionDto>> GetCompetition(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            var competitionDto = new CompetitionDto
            {
                CompetitionId = competition.CompetitionId,
                Name = competition.Name,
                Description = competition.Description,
                ResponsibleEmail = competition.ResponsibleEmail,
                Date = competition.Date,
                Timing = competition.Timing,
                Tags = competition.Tags,
                TargetAudience = competition.TargetAudience,
                URL = competition.URL,
                Photo = competition.Photo,
                CoverPhoto = competition.CoverPhoto
            };

            return competitionDto;
        }

        // POST: api/Competition
        [HttpPost]
        public async Task<ActionResult<CompetitionDto>> CreateCompetition(CompetitionDto competitionDto)
        {
            var competition = new Competition
            {
                Name = competitionDto.Name,
                Description = competitionDto.Description,
                ResponsibleEmail = competitionDto.ResponsibleEmail,
                Date = competitionDto.Date,
                Timing = competitionDto.Timing,
                Tags = competitionDto.Tags,
                TargetAudience = competitionDto.TargetAudience,
                URL = competitionDto.URL,
                Photo = competitionDto.Photo,
                CoverPhoto = competitionDto.CoverPhoto
            };

            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetition), new { id = competition.CompetitionId }, competitionDto);
        }

        // PUT: api/Competition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(int id, CompetitionDto competitionDto)
        {
            if (id != competitionDto.CompetitionId)
            {
                return BadRequest();
            }

            var competition = new Competition
            {
                CompetitionId = competitionDto.CompetitionId,
                Name = competitionDto.Name,
                Description = competitionDto.Description,
                ResponsibleEmail = competitionDto.ResponsibleEmail,
                Date = competitionDto.Date,
                Timing = competitionDto.Timing,
                Tags = competitionDto.Tags,
                TargetAudience = competitionDto.TargetAudience,
                URL = competitionDto.URL,
                Photo = competitionDto.Photo,
                CoverPhoto = competitionDto.CoverPhoto
            };

            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Competition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competitions.Any(e => e.CompetitionId == id);
        }
    }
}
