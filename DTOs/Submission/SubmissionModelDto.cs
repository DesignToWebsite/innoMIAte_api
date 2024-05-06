namespace innomiate_api.DTOs.Submission
{
    public class SubmissionModelDto
    {
        public int SubmissionModelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompetitionId { get; set; }
        public ICollection<FileModelDto> FileModels { get; set; }
    }
}
