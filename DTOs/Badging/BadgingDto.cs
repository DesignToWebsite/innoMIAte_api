namespace innomiate_api.DTOs.Badging
{
    public class BadgingDto
    {
        public int BadgingId { get; set; }
        public int CompetitionId { get; set; }
        public ICollection<BadgeDto> Badges { get; set; }
    }
}
