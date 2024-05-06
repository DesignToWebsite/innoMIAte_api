using INNOMIATE_API.Models;
using System.IO;

namespace innomiate_api.Models.Submission
{
    public class SubmissionModel
    {
        public int SubmissionModelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation property for Competition
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        // Navigation property for FileModels
        public ICollection<FileModel> FileModels { get; set; }
    }
}
