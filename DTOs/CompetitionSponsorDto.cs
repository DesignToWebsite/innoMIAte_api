namespace INNOMIATE_API.DTOs
{
    public class CompetitionSponsorDto
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string Logo { get; set; }

        public int CompetitionId { get; set; }
        // public CompetitionDto Competition { get; set; }
    }
}