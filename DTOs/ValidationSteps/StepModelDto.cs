namespace innomiate_api.DTOs.ValidationSteps
{
    public class StepModelDto
    {
        public int StepModelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubmissionType SubmissionType { get; set; }
        public ICollection<StepTemplateModelDto> StepTemplates { get; set; }
        public int CompetitionId { get; set; }
        public ICollection<int> TeamStepSubmissionIds { get; set; }
    }
}
