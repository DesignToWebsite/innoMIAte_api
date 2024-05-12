using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CompetitionService _competitionService;
        public CompetitionController(ApplicationDbContext context, CompetitionService competitionService)
        {
            _context = context;
            _competitionService = competitionService;
        }

        
        // GET all the competition
        [HttpGet]
        public async Task<IActionResult> GetAllCompetitions()
        {
            var competitions = await _competitionService.GetAllCompetitions();
            return Ok(competitions);
        }
        
        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompetitionById(int id)
        {
            var competition = await _competitionService.GetCompetitionById(id);

            if (competition == null)
            {
                return NotFound();
            }

            
            return Ok(competition);
        }

// GET: api/Competition/5
        [HttpGet("/url/{url}")]
        public async Task<ActionResult<Competition>> GetCompetitionByUrl(string url, [FromQuery] bool ParticipantInfo = false)
        {
            var competition = ParticipantInfo? 
                        await _competitionService.GetParticipantsCompetitionByUrl(url) :
                        await _competitionService.GetCompetitionByUrl(url);

            if (competition == null)
            {
                return NotFound();
            }
           
            return competition;
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
                Tags = competitionDto.Tags,
                TargetAudience = competitionDto.TargetAudience,
                URL = competitionDto.URL,
                Photo = competitionDto.Photo,
                CoverPhoto = competitionDto.CoverPhoto,
                DescriptionTop = competitionDto.DescriptionTop,
                DeadLine = competitionDto.DeadLine,
                StartDate = competitionDto.StartDate,
                Theme = competitionDto.Theme,
                Rules = competitionDto.Rules,
                Organizers = competitionDto.Organizers,
                Partnerships = competitionDto.Partnerships,
                Sponsors = competitionDto.Sponsors,
                 Location = competitionDto.Location,
                 PdfRules = competitionDto.PdfRules,
                Resource = competitionDto.Resource,
                Gallery = competitionDto.Gallery,
                Prizes = competitionDto.Prizes
            };

            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitionById), new { id = competition.CompetitionId }, competitionDto);
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
                DescriptionTop = competitionDto.DescriptionTop,
                DeadLine = competitionDto.DeadLine,
                StartDate = competitionDto.StartDate,
                Tags = competitionDto.Tags,
                TargetAudience = competitionDto.TargetAudience,
                URL = competitionDto.URL,
                Photo = competitionDto.Photo,
                CoverPhoto = competitionDto.CoverPhoto,
                Theme = competitionDto.Theme,
                Rules = competitionDto.Rules,
                Organizers = competitionDto.Organizers,
                Partnerships = competitionDto.Partnerships,
                Sponsors = competitionDto.Sponsors,
                 Location = competitionDto.Location,
                 PdfRules = competitionDto.PdfRules,
                Resource = competitionDto.Resource,
                Gallery = competitionDto.Gallery,
                Prizes = competitionDto.Prizes
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
