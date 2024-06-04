namespace innomiate_api.DTOs
{
    public class UpdateParticipantDto
    {
        public int ParticipantId { get; set; }
        public int? TeamId { get; set; }
        public bool IsLeader { get; set; }
    }
}
