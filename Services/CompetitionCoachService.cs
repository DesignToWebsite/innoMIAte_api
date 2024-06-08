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
    public class CompetitionCoachService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionCoachService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionCoachDto> CreateCoach(CompetitionCoachDto coachDto)
        {
            var coach = new CompetitionCoach
            {
                UserId = coachDto.UserId,
                CompetitionId = coachDto.CompetitionId
            };

            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();

            coachDto.UserId = coach.UserId; // Update the DTO with the generated ID
            return coachDto;
        }

        public async Task UpdateCoach(int id, CompetitionCoachDto coachDto)
        {
            var coachToUpdate = await _context.Coaches.FindAsync(id);

            if (coachToUpdate == null)
            {
                throw new ArgumentException("Coach not found");
            }

            coachToUpdate.UserId = coachDto.UserId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoach(int id)
        {
            var coachToDelete = await _context.Coaches.FindAsync(id);

            if (coachToDelete == null)
            {
                throw new ArgumentException("Coach not found");
            }

            _context.Coaches.Remove(coachToDelete);
            await _context.SaveChangesAsync();
        }

        public List<CompetitionCoachDto> GetCoachesByCompetitionId(int competitionId)
        {
            var coaches = _context.Coaches
                .Where(coach => coach.CompetitionId == competitionId)
                .Select(coach => new CompetitionCoachDto
                {
                    UserId = coach.UserId,
                    CompetitionId = coach.CompetitionId
                })
                .ToList();

            return coaches;
        }
    }
}
