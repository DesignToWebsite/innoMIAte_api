namespace innomiate_api.Models.Prizing
{
    public class PrizeType
    {
        public int PrizeTypeId { get; set; }
        public string Name { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }
    }

}
