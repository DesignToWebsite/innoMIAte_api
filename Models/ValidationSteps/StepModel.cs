using INNOMIATE_API.Models;

namespace innomiate_api.Models.ValidationSteps
{
    public class StepModel
    {
        public int StepModelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubmissionType SubmissionType { get; set; }
        public List<StepTemplateModel> StepTemplates { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public ICollection<TeamStepSubmission> TeamStepSubmissions { get; set; }
    }
}
public enum SubmissionType
{
    CodeRepository,
    VideoPresentation,
    DemoApp,
    Document,
    PowerPointDocument
}