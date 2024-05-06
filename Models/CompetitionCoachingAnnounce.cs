using INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations;

namespace innomiate_api.Models
{
    public class CompetitionCoachingAnnounce
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Foreign key
        [Required]
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; } // Navigation Property
    }
}
