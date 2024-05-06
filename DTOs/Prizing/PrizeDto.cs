namespace innomiate_api.DTOs.Prizing
{
    public class PrizeDto
    {
        public int PrizeId { get; set; }
        public int BeginningRank { get; set; }
        public int EndingRank { get; set; }
        public int PrizeTypeId { get; set; }
        public PrizeTypeDto PrizeType { get; set; }
    }
}
