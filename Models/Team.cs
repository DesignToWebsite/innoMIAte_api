using innomiate_api.Models.ValidationSteps;
using INNOMIATE_API.Models;

namespace innomiate_api.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public int? TeamLeaderUserId { get; set; } // Foreign key for UserId
        public int? TeamLeaderCompetitionId { get; set; } // Foreign key for CompetitionId
        // Navigation properties
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public ICollection<CompetitionParticipant>? Participants { get; set; }
        public ICollection<TeamStepSubmission>? TeamStepsSubmissions { get; set; }
        public CompetitionParticipant TeamLeader { get; set; } // Navigation property for TeamLeader


        public ICollection<StepCompetition> Steps { get; set; } 
    }
}
