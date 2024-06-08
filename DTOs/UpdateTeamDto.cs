namespace innomiate_api.DTOs
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public int CompetitionId { get; set; }
    }
}
