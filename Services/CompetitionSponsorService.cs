using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;

namespace innomiate_api.Services
{
    public class CompetitionSponsorService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionSponsorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionSponsorDto> CreateSponsor(CompetitionSponsorDto sponsorDto)
        {
            var sponsor = new CompetitionSponsor
            {
                SponsorId = sponsorDto.SponsorId,
                SponsorName = sponsorDto.SponsorName,
                logo = sponsorDto.Logo,
                CompetitionId = sponsorDto.CompetitionId
            };

            _context.Sponsors.Add(sponsor);
            await _context.SaveChangesAsync();

            sponsorDto.SponsorId = sponsor.SponsorId; // Update the DTO with the generated ID
            return sponsorDto;
        }

        public async Task UpdateSponsor(int id, CompetitionSponsorDto sponsorDto)
        {
            var sponsorToUpdate = await _context.Sponsors.FindAsync(id);

            if (sponsorToUpdate == null)
            {
                throw new ArgumentException("Sponsor not found");
            }

            sponsorToUpdate.SponsorName = sponsorDto.SponsorName;
            sponsorToUpdate.logo = sponsorDto.Logo;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSponsor(int id)
        {
            var sponsorToDelete = await _context.Sponsors.FindAsync(id);

            if (sponsorToDelete == null)
            {
                throw new ArgumentException("Sponsor not found");
            }

            _context.Sponsors.Remove(sponsorToDelete);
            await _context.SaveChangesAsync();
        }

        public List<CompetitionSponsorDto> GetSponsorsByCompetitionId(int competitionId)
        {
            var sponsors = _context.Sponsors
                .Where(sponsor => sponsor.CompetitionId == competitionId)
                .Select(sponsor => new CompetitionSponsorDto
                {
                    SponsorId = sponsor.SponsorId,
                    SponsorName = sponsor.SponsorName,
                    Logo = sponsor.logo,
                    CompetitionId = sponsor.CompetitionId
                })
                .ToList();

            return sponsors;
        }
    }
}
