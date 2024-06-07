using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Data;

namespace innomiate_api.Services
{
    public class GroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Participants)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);

            if (group == null)
                return null;

            return new GroupDTO
            {
                GroupId = group.GroupId,
                Name = group.Name,
                Slogan = group.Slogan,
                ProjectName = group.ProjectName,
                ProjectDescription = group.ProjectDescription,
                ProjectImage = group.ProjectImage,
                Participants = group.Participants.Select(p => new CParticipantDTO
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    IsLeader = p.IsLeader
                }).ToList()
            };
        }

        // hadi bach nzid participant lteam
        public async Task<GroupDTO> UpdateParticipantGroupAsync(int groupId, int participantId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
                return null;

            var participant = await _context.Participants.FindAsync(participantId);
            if (participant == null)
                return null;

            participant.GroupId = groupId;
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();

            return await GetGroupByIdAsync(groupId);
        }


        //hadi bach njib ga3 lgroups ta3 competition
        public async Task<List<GroupDTO>> GetGroupsByCompetitionIdAsync(int competitionId)
        {
            var groups = await _context.Groups
                .Where(g => g.CompetitionId == competitionId)
                .Include(g => g.Participants)
                .ThenInclude(p => p.User)
                .ToListAsync();

            return groups.Select(g => new GroupDTO
            {
                GroupId = g.GroupId,
                Name = g.Name,
                Slogan = g.Slogan,
                ProjectName = g.ProjectName,
                ProjectDescription = g.ProjectDescription,
                ProjectImage = g.ProjectImage,
                Participants = g.Participants.Select(p => new CParticipantDTO
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    IsLeader = p.IsLeader
                }).ToList()
            }).ToList();
        }
    }
}
