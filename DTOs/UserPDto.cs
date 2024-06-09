namespace innomiate_api.DTOs
{
    public class UserPDto
    {
        public int ParticipantId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Github { get; set; }
        public string? Linkedin { get; set; }
    }
}
