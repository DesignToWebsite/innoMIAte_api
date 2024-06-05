namespace INNOMIATE_API.DTOs
{
    public class CompetitionParticipantDto
    {
        public int UserId { get; set; }
        public int CompetitionId { get; set; }

        public int? TeamId { get; set; }
        public bool IsLeader { get; set; } = false;
    }
}
