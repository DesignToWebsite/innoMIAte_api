namespace innomiate_api.Models.ValidationSteps
{
    public class TeamStepSubmission
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
