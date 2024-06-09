namespace innomiate_api.DTOs
{
    public class CompetitionParticipantsPerTeamDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsLeader { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
