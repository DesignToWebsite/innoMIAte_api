using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace innomiate_api.Services
{
    public class CompetitionParticipantService
    {
        private readonly ApplicationDbContext _context;

        public CompetitionParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionParticipantDto> CreateParticipant(CompetitionParticipantDto participantDto)
        {
            var participant = new CompetitionParticipant
            {
                UserId = participantDto.UserId,
                CompetitionId = participantDto.CompetitionId,
               //
               //
               //
            //TeamId = participantDto.TeamId,
                IsConfirmed = participantDto.IsConfirmed,
                GroupId = participantDto.GroupId,
            };

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            participantDto.UserId = participant.UserId; // Update the DTO with the generated ID
            return participantDto;
        }

        public async Task UpdateParticipant(int id, CompetitionParticipantDto participantDto)
        {
            var participantToUpdate = await _context.Participants.FindAsync(id);

            if (participantToUpdate == null)
            {
                throw new ArgumentException("Participant not found");
            }

            participantToUpdate.UserId = participantDto.UserId;
         //   participantToUpdate.TeamId = participantDto.TeamId;
            participantToUpdate.IsLeader = participantDto.IsLeader;
            participantToUpdate.IsConfirmed = participantDto.IsConfirmed;
            participantToUpdate.GroupId = participantDto.GroupId;


            await _context.SaveChangesAsync();
        }

        public async Task DeleteParticipant(int id)
        {
            var participantToDelete = await _context.Participants.FindAsync(id);

            if (participantToDelete == null)
            {
                throw new ArgumentException("Participant not found");
            }

            _context.Participants.Remove(participantToDelete);
            await _context.SaveChangesAsync();
        }

        public List<UserParticipantDto> GetParticipantsByCompetitionId(int competitionId)
        {
            var participants = _context.Participants
                .Where(participant => participant.CompetitionId == competitionId)
                .Select(participant => new UserParticipantDto
                {
                    UserId = participant.UserId,
                    CompetitionId = participant.CompetitionId,
                    IsLeader = participant.IsLeader,
                    IsConfirmed = participant.IsConfirmed,
                    GroupId = participant.GroupId,
                    GroupName = participant.Group.Name, 


                    FirstName = participant.User.FirstName,
                    LastName = participant.User.LastName,
                    Email = participant.User.Email,
                    UserName = participant.User.UserName
                })
                .ToList();

            return participants;
        }


        public bool ConfirmParticipation(int userId, int competitionId)
        {
            var participant = _context.Participants
                                      .SingleOrDefault(cp => cp.UserId == userId && cp.CompetitionId == competitionId);

            if (participant == null)
            {
                return false; 
            }

            participant.IsConfirmed = true;
            _context.SaveChanges();
            return true; 
        }
        /*
                      public async Task CreateTeamAndAssignLeader(int participantId, TeamDto teamDto)
                      {
                          var team = new Team
                          {
                              Name = teamDto.Name,
                              Slogan = teamDto.Slogan,
                              ProjectName = teamDto.ProjectName,
                              ProjectDescription = teamDto.ProjectDescription,
                              CompetitionId = teamDto.CompetitionId,
                              ProjectImage = teamDto.ProjectImage,
                          };

                          // Add the team to the database
                        //  _context.Teams.Add(team);
                          await _context.SaveChangesAsync();

                          // Retrieve the existing participant
                          var participant = await _context.Participants
                                  .SingleOrDefaultAsync(p => p.UserId == participantId && p.CompetitionId == team.CompetitionId)
                                  ?? throw new Exception("Participant not found");
                          //Update the participant"s TeamId and ISleader 
                        //  participant.TeamId = team.TeamId;
                          participant.IsLeader = true;
                          // participant.IsConfirmed = true;
                          //Save the changes
                          _context.Participants.Update(participant);
                          await _context.SaveChangesAsync();

                      }*/
    }
}
