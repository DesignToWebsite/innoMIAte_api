namespace innomiate_api.DTOs.Badging
{
    public class BadgeDto
    {
        public int BadgeId { get; set; }
        public string BadgeType { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Criteria { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

}
