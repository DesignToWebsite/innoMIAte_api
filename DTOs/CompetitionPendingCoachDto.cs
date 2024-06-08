namespace innomiate_api.DTOs
{
    public class CompetitionPendingCoachDto
    {
        public int Id { get; set; }
        public string CoachEmail { get; set; }
        public string Comment { get; set; }
        public int CompetitionId { get; set; }
    }
}
