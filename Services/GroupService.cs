using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using System.Globalization;

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

        public async Task<GroupDTO> CreateGroupAsync(int participantId, string groupName)
        {
            var participant = await _context.Participants
                .Include(p => p.User)
                .Include(p => p.Competition)
                .FirstOrDefaultAsync(p => p.Id == participantId);

            if (participant == null)
                return null;

            var newGroup = new Group
            {
                Name = groupName,
                CompetitionId = participant.CompetitionId,
                Participants = new List<CompetitionParticipant> { participant }
            };

            participant.Group = newGroup;
            participant.IsLeader = true;

            _context.Groups.Add(newGroup);
            await _context.SaveChangesAsync();

            return new GroupDTO
            {
                GroupId = newGroup.GroupId,
                Name = newGroup.Name,
                Slogan = newGroup.Slogan,
                ProjectName = newGroup.ProjectName,
                ProjectDescription = newGroup.ProjectDescription,
                ProjectImage = newGroup.ProjectImage,
                Participants = newGroup.Participants.Select(p => new CParticipantDTO
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    IsLeader = p.IsLeader
                }).ToList()
            };
        }


        /// <summary>
        public async Task<List<CompetitionParticipantsPerTeamDto>> GetParticipantsByGroupIdAsync(int groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Participants)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);

            if (group == null)
                return null;

            return group.Participants.Select(p => new CompetitionParticipantsPerTeamDto
            {
                Id = p.Id,
                UserId = p.UserId,
                IsLeader = p.IsLeader,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                Email = p.User.Email,
                Username = p.User.UserName
            }).ToList();
        }


        //Création de Groupe et leader 
        /*  public async Task<GroupDTO> CreateGroupAsync(int participantId, string groupName)
          {
              // Find the participant and include the User and Competition information
           /*   var participant = await _context.Participants
                  .Include(p => p.User)
                  .Include(p => p.Competition)
                  .FirstOrDefaultAsync(p => p.Id == participantId); */

        /* if (participant == null)
             return null; 

            var newGroup = new Group
            {
                Name = groupName,
                CompetitionId = participant.CompetitionId,
                Participants = new List<CompetitionParticipant> { participant }
            };

            participant.Group = newGroup;
            participant.IsLeader = true; */

        //  _context.Groups.Add(newGroup);

        // Create a new History entry for the group creation
        //var history = History.CreateGroupCreatedHistory(groupName);
        //   _context.History.Add(history);

        // await _context.SaveChangesAsync();

        /*  return null;*/

        /*new GroupDTO
    {
        GroupId = newGroup.GroupId,
        Name = newGroup.Name,
        Slogan = newGroup.Slogan,
        ProjectName = newGroup.ProjectName,
        ProjectDescription = newGroup.ProjectDescription,
        ProjectImage = newGroup.ProjectImage,
        Participants = newGroup.Participants.Select(p => new CParticipantDTO
        {
            Id = p.Id,
            UserId = p.UserId,
            IsLeader = p.IsLeader
        }).ToList()
    };

    }*/

        public async Task<bool> DeleteGroupAsync(int groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Participants)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);

            if (group == null)
            {
                return false;
            }

            foreach (var participant in group.Participants)
            {
                participant.GroupId = null;
            }

            _context.Groups.Remove(group);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveParticipantFromGroupAsync(int participantId)
        {
            var participant = await _context.Participants
                .FirstOrDefaultAsync(p => p.Id == participantId);

            if (participant == null )
            {
                return false;
            }
         

            // Set the GroupId of the participant to null
            participant.GroupId = null;


            // Save changes
            await _context.SaveChangesAsync();

            return true;
        }

    }

}
