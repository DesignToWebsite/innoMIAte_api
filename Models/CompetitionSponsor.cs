using System.ComponentModel.DataAnnotations;

namespace INNOMIATE_API.Models
{
    public class CompetitionSponsor
    {
        [Key]
        public int SponsorId { get; set; }

        public string SponsorName { get; set; }
        public string logo { get; set; }

        [Required]
        public int CompetitionId { get; set; }
        // Navigation References 
        public Competition Competition { get; set; }
    }
}
