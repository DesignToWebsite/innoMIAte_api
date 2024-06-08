namespace innomiate_api.Models.Submission
{
    public class TeamSubmission
    {
        public int TeamSubmissionId { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int SubmissionModelId { get; set; }
        public SubmissionModel SubmissionModel { get; set; }

        // Collection of files
        public ICollection<TeamSubmissionFile> TeamSubmissionFiles { get; set; }
    }
}
