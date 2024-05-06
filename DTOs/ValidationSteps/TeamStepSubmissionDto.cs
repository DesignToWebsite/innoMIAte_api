using innomiate_api.Models.ValidationSteps;
using innomiate_api.Models;

namespace innomiate_api.DTOs.ValidationSteps
{
    public class TeamStepSubmissionDto
    {
        public int TeamStepSubmissionId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int StepId { get; set; }
        public StepModel Step { get; set; }
        public string SubmissionFilePath { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
