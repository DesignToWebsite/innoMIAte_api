namespace INNOMIATE_API.DTOs
{
    public class CompetitionContributorDto
    {
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public string Logo { get; set; }

        public int CompetitionId { get; set; }
    }
}