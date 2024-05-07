using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;

namespace INNOMIATE_API.Services
{
    public class CompetitionService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionDto> GetCompetitionById(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
                return null;

            var competitionDto = new CompetitionDto
            {
                CompetitionId = competition.CompetitionId,
                Name = competition.Name,
                Description = competition.Description,
                ResponsibleEmail = competition.ResponsibleEmail,
                Date = competition.Date,
                Tags = competition.Tags,
                TargetAudience = competition.TargetAudience,
                URL = competition.URL,
                Photo = competition.Photo,
                CoverPhoto = competition.CoverPhoto,
                Theme = competition.Theme,
                Rules = competition.Rules,
                Organizers = competition.Organizers,
                Partnerships = competition.Partnerships,
                Sponsors = competition.Sponsors,
                Location = competition.Location,
                PdfRules = competition.PdfRules,
                Resource = competition.Resource,
                Gallery = competition.Gallery
            };

            return competitionDto;
        }

        public async Task<CompetitionDto?> GetCompetitionByUrl(string id)
        {
            var competition = await _context.Competitions
                    .FirstOrDefaultAsync(c => c.URL == id);
            if (competition == null)
                return null;

            var competitionDto = new CompetitionDto
            {
                CompetitionId = competition.CompetitionId,
                Name = competition.Name,
                Description = competition.Description,
                ResponsibleEmail = competition.ResponsibleEmail,
                Date = competition.Date,
                Tags = competition.Tags,
                TargetAudience = competition.TargetAudience,
                URL = competition.URL,
                Photo = competition.Photo,
                CoverPhoto = competition.CoverPhoto,
                Theme = competition.Theme,
                Rules = competition.Rules,
                Organizers = competition.Organizers,
                Partnerships = competition.Partnerships,
                Sponsors = competition.Sponsors,
                Location = competition.Location,
                PdfRules = competition.PdfRules,
                Resource = competition.Resource,
                Gallery = competition.Gallery
            };

            return competitionDto;
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitions()
        {
            // var competitions = await _context.Competitions.ToListAsync();
            // var competitionDtos = competitions.Select(c => new CompetitionDto
            // {
            //     CompetitionId = c.CompetitionId,
            //     Name = c.Name,
            //     Description = c.Description,
            //     ResponsibleEmail = c.ResponsibleEmail,
            //     Date = c.Date,
            //     Timing = c.Timing,
            //     Tags = c.Tags,
            //     TargetAudience = c.TargetAudience,
            //     URL = c.URL,
            //     Photo = c.Photo,
            //     CoverPhoto = c.CoverPhoto
            // }).ToList();

            // return competitionDtos;
            return await _context.Competitions.ToListAsync();
        }

        public async Task<bool> CreateCompetition(CompetitionDto competitionDto)
        {
            var competition = new Competition
            {
                Name = competitionDto.Name,
                Description = competitionDto.Description,
                ResponsibleEmail = competitionDto.ResponsibleEmail,
                DescriptionTop = competitionDto.DescriptionTop,
                DeadLine = competitionDto.DeadLine,
                Date = competitionDto.Date,
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
                Gallery = competitionDto.Gallery
            };

            try
            {
                _context.Competitions.Add(competition);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCompetition(int id, CompetitionDto competitionDto)
        {
            if (id != competitionDto.CompetitionId)
            {
                return false;
            }

            var competition = new Competition
            {
                CompetitionId = competitionDto.CompetitionId,
                Name = competitionDto.Name,
                Description = competitionDto.Description,
                DescriptionTop = competitionDto.DescriptionTop,
                DeadLine = competitionDto.DeadLine,
                StartDate = competitionDto.StartDate,
                ResponsibleEmail = competitionDto.ResponsibleEmail,
                Date = competitionDto.Date,
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
                Gallery = competitionDto.Gallery
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteCompetition(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                return false;
            }

            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competitions.Any(e => e.CompetitionId == id);
        }
    }
}
