using System.ComponentModel.DataAnnotations;

namespace INNOMIATE_API.Models
{
    public class CompetitionJudge
    {

        public int UserId { get; set; }
        public int CompetitionId { get; set; }

        // Navigation References 
        public User User { get; set; }
        public Competition Competition { get; set; }
    }
}
