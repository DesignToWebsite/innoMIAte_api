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
                TeamId = participantDto.TeamId
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
            participantToUpdate.TeamId = participantDto.TeamId;

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

        public List<CompetitionParticipantDto> GetParticipantsByCompetitionId(int competitionId)
        {
            var participants = _context.Participants
                .Where(participant => participant.CompetitionId == competitionId)
                .Select(participant => new CompetitionParticipantDto
                {
                    UserId = participant.UserId,
                    CompetitionId = participant.CompetitionId,
                    TeamId = participant.TeamId
                })
                .ToList();

            return participants;
        }
    }
}
