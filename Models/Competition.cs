using innomiate_api.Models;
using innomiate_api.Models.Badging;
using innomiate_api.Models.Prizing;
using innomiate_api.Models.Submission;
using innomiate_api.Models.ValidationSteps;

namespace INNOMIATE_API.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResponsibleEmail { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Timing { get; set; }
        public List<String> Tags { get; set; }
        public string TargetAudience { get; set; }
        public string URL { get; set; }
        public string Photo { get; set; }
        public string CoverPhoto { get; set; }

        // Navigation references 
        public ICollection<CompetitionParticipant> Participants { get; set; }
        public ICollection<CompetitionCoach> Coaches { get; set; }
        public ICollection<CompetitionJudge> Judges { get; set; }
        public ICollection<CompetitionContributor> Contributors { get; set; }
        public ICollection<CompetitionSponsor> Sponsors { get; set; }
        public List<StepModel> StepModels { get; set; }
        public List<Team> Teams { get; set; }
        public SubmissionModel SubmissionModel { get; set; }
        public Prizing Prizing { get; set; }
        public Badging Badging { get; set; }


        public CompetitionCreator Creator { get; set; }


    }
}
