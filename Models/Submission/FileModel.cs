using Microsoft.VisualBasic.FileIO;

namespace innomiate_api.Models.Submission
{
    public class FileModel
    {
        public int FileModelId { get; set; }
        public String Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation property for SubmissionModel
        public int SubmissionModelId { get; set; }
        public SubmissionModel SubmissionModel { get; set; }
    }
 
}
