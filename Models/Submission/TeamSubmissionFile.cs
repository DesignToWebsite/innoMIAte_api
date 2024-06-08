namespace innomiate_api.Models.Submission
{
    public class TeamSubmissionFile
    {
                // The actual file content
        public byte[] File { get; set; }

        // Additional properties
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int TeamSubmissionFileId { get; set; }

        // Foreign key to TeamSubmission
        public int TeamSubmissionId { get; set; }

        public TeamSubmission TeamSubmission { get; set; }

        // Foreign key to FileModel
        public int FileModelId { get; set; }
        public FileModel FileModel { get; set; }
    }
}
