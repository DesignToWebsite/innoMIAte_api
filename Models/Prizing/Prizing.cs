using INNOMIATE_API.Models;

namespace innomiate_api.Models.Prizing
{
    public class Prizing
    {
        public int PrizingId { get; set; }
        public int CompetitionId { get; set; } // Foreign key
        public Competition Competition { get; set; } // Navigation property

        // List of prizes
        public List<Prize> Prizes { get; set; }
    }
}
