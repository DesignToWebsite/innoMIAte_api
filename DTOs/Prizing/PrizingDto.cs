namespace innomiate_api.DTOs.Prizing
{
    public class PrizingDto
    {
        public int PrizingId { get; set; }
        public int CompetitionId { get; set; }
        public ICollection<PrizeDto> Prizes { get; set; }
    }
}
