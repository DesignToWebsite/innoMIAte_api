namespace innomiate_api.Services
{
    using global::INNOMIATE_API.Data;
    using global::innomiate_api.DTOs;
    using global::INNOMIATE_API.Models;


    namespace INNOMIATE_API.Services
    {
        public class ParticipantService
        {
            private readonly ApplicationDbContext _context;

            public ParticipantService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ParticipantDto> CreateParticipantAsync(CreateParticipantDto createParticipantDto)
            {
                var participant = new CompetitionParticipant
                {
                    UserId = createParticipantDto.UserId,
                    CompetitionId = createParticipantDto.CompetitionId
                };

                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();

                return new ParticipantDto
                {
                    ParticipantId = participant.Id,
                    UserId = participant.UserId,
                    CompetitionId = participant.CompetitionId
                };
            }

            public async Task<bool> DeleteParticipantAsync(int participantId)
            {
                var participant = await _context.Participants.FindAsync(participantId);
                if (participant == null)
                {
                    return false;
                }

                _context.Participants.Remove(participant);
                await _context.SaveChangesAsync();
                return true;
            }
            /*
            public async Task<ParticipantDto> UpdateParticipantTeamAsync(UpdateParticipantTeamDto updateParticipantTeamDto)
            {
                var participant = await _context.Participants.FindAsync(updateParticipantTeamDto.ParticipantId);
                if (participant == null)
                {
                    return null;
                }

                participant.TeamId = updateParticipantTeamDto.TeamId;
                await _context.SaveChangesAsync();

                return new ParticipantDto
                {
                    ParticipantId = participant.Id,
                    UserId = participant.UserId,
                    CompetitionId = participant.CompetitionId,
                    TeamId = participant.TeamId,
                    IsLeader = participant.IsLeader
                };
            } */

            public async Task<ParticipantDto> UpdateParticipantAsync(UpdateParticipantDto updateParticipantDto)
            {
                var participant = await _context.Participants.FindAsync(updateParticipantDto.ParticipantId);
                if (participant == null)
                {
                    return null;
                }

              //  participant.TeamId = updateParticipantDto.TeamId;
                participant.IsLeader = updateParticipantDto.IsLeader;
                await _context.SaveChangesAsync();

                return new ParticipantDto
                {
                    ParticipantId = participant.Id,
                    UserId = participant.UserId,
                    CompetitionId = participant.CompetitionId,
                  //  TeamId = participant.TeamId,
                    IsLeader = participant.IsLeader
                };
            }
        }
    }

}
