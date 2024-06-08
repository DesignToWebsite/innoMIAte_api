namespace innomiate_api.DTOs.Submission
{
    public class TeamSubmissionDto
    {
        public int TeamSubmissionId { get; set; }
        public int TeamId { get; set; }
        public int SubmissionModelId { get; set; }
        public ICollection<TeamSubmissionFileDto> TeamSubmissionFiles { get; set; }
    }
}
