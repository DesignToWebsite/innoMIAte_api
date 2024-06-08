namespace innomiate_api.DTOs.Submission
{
    public class TeamSubmissionFileDto
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int TeamSubmissionId { get; set; }
        public int TeamSubmissionFileId { get; set; }
        public int FileModelId { get; set; }
    }
}
