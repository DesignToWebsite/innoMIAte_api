using System.IO;

namespace innomiate_api.Models
{
    public class CompetitionPrize
    {
        public int BeginningRank { get; set; }
        public int EndingRank { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }
    }
}
