using innomiate_api.DTOs.ValidationSteps;

namespace innomiate_api.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public int? TeamLeaderUserId { get; set; }
        public int? TeamLeaderCompetitionId { get; set; }
        public int CompetitionId { get; set; }
        public ICollection<int> ParticipantIds { get; set; }
        public ICollection<TeamStepSubmissionDto> TeamStepsSubmissions { get; set; }
    }
}
