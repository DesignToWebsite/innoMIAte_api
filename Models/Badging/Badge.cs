namespace innomiate_api.Models.Badging
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string BadgeType { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Criteria { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public int BadgingId { get; set; }
        public Badging Badging { get; set; }
    }
}
