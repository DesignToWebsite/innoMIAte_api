using System.ComponentModel.DataAnnotations;

namespace INNOMIATE_API.Models
{
    public class CompetitionContributor
    
          {
        [Key]
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public string logo { get; set; }
        [Required]
        public int CompetitionId { get; set; }

        // Navigation References 
        public Competition Competition { get; set; }
    
}
}
