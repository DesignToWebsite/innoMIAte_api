using System;
using System.Linq;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;

namespace innomiate_api.Services
{
    public class CompetitionJudgeService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionJudgeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionJudgeDto> CreateJudge(CompetitionJudgeDto judgeDto)
        {
            var judge = new CompetitionJudge
            {
                UserId = judgeDto.UserId,
                CompetitionId = judgeDto.CompetitionId
            };

            _context.Judges.Add(judge);
            await _context.SaveChangesAsync();

            judgeDto.UserId = judge.UserId; // Update the DTO with the generated ID
            return judgeDto;
        }

        public async Task UpdateJudge(int id, CompetitionJudgeDto judgeDto)
        {
            var judgeToUpdate = await _context.Judges.FindAsync(id);

            if (judgeToUpdate == null)
            {
                throw new ArgumentException("Judge not found");
            }

            judgeToUpdate.UserId = judgeDto.UserId;
            judgeToUpdate.CompetitionId = judgeDto.CompetitionId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJudge(int id)
        {
            var judgeToDelete = await _context.Judges.FindAsync(id);

            if (judgeToDelete == null)
            {
                throw new ArgumentException("Judge not found");
            }

            _context.Judges.Remove(judgeToDelete);
            await _context.SaveChangesAsync();
        }

        public CompetitionJudgeDto GetJudgeById(int id)
        {
            var judge = _context.Judges.FirstOrDefault(j => j.UserId == id);

            if (judge == null)
            {
                throw new ArgumentException("Judge not found");
            }

            var judgeDto = new CompetitionJudgeDto
            {
                UserId = judge.UserId,
                CompetitionId = judge.CompetitionId
            };

            return judgeDto;
        }
    }
}
