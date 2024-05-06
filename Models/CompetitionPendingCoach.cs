using INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations;

namespace innomiate_api.Models
{
    public class CompetitionPendingCoach
    {
        public int Id { get; set; }
        public string CoachEmail { get; set; }
        public string Comment { get; set; }
        // Foreign key
        [Required]
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; } 
    }
}
