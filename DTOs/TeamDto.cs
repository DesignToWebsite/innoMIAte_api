using innomiate_api.DTOs.ValidationSteps;

namespace innomiate_api.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public int CompetitionId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string? ProjectImage  { get; set; }
    }
}
