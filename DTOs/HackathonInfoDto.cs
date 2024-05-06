namespace innomiate_api.DTOs
{
    public class HackathonInfoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResponsibleEmail { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Timing { get; set; }
        public List<string> Tags { get; set; }
        public string TargetAudience { get; set; }
        public string URL { get; set; }
        public string Photo { get; set; }
        public string CoverPhoto { get; set; }
    }
}
