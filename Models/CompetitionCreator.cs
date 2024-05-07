using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models
{
    public class CompetitionCreator
    {
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
        // Navigation References 
        public string Role { get; set; }
        public User User { get; set; }
        public Competition Competition { get; set; }
    }
}
