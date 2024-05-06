namespace innomiate_api.DTOs.Prizing
{
    public class PrizeTypeDto
    {
        public int PrizeTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }
}
