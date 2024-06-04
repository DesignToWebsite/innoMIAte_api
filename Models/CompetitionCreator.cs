using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models
{
    public class CompetitionCreator
    {
        [Key]
        public int CreatorId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        // Navigation References 
        public User User { get; set; }
        public Competition Competition { get; set; }
    }
}
