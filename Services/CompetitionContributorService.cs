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
    public class CompetitionContributorService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionContributorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionContributorDto> CreateContributor(CompetitionContributorDto contributorDto)
        {
            var contributor = new CompetitionContributor
            {
                ContributorId = contributorDto.ContributorId,
                ContributorName = contributorDto.ContributorName,
                logo = contributorDto.Logo,
                CompetitionId = contributorDto.CompetitionId
            };

            _context.Contributors.Add(contributor);
            await _context.SaveChangesAsync();

            contributorDto.ContributorId = contributor.ContributorId; // Update the DTO with the generated ID
            return contributorDto;
        }

        public async Task UpdateContributor(int id, CompetitionContributorDto contributorDto)
        {
            var contributorToUpdate = await _context.Contributors.FindAsync(id);

            if (contributorToUpdate == null)
            {
                throw new ArgumentException("Contributor not found");
            }

            contributorToUpdate.ContributorName = contributorDto.ContributorName;
            contributorToUpdate.logo = contributorDto.Logo;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteContributor(int id)
        {
            var contributorToDelete = await _context.Contributors.FindAsync(id);

            if (contributorToDelete == null)
            {
                throw new ArgumentException("Contributor not found");
            }

            _context.Contributors.Remove(contributorToDelete);
            await _context.SaveChangesAsync();
        }

        public List<CompetitionContributorDto> GetContributorsByCompetitionId(int competitionId)
        {
            var contributors = _context.Contributors
                .Where(contributor => contributor.CompetitionId == competitionId)
                .Select(contributor => new CompetitionContributorDto
                {
                    ContributorId = contributor.ContributorId,
                    ContributorName = contributor.ContributorName,
                    Logo = contributor.logo,
                    CompetitionId = contributor.CompetitionId
                })
                .ToList();

            return contributors;
        }
    }
}
