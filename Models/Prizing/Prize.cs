using System.IO;

namespace innomiate_api.Models.Prizing
{
    public class Prize
    {
        public int PrizeId { get; set; }
        public int BeginningRank { get; set; }
        public int EndingRank { get; set; }

        // Navigation properties
        public int PrizeTypeId { get; set; }
        public PrizeType PrizeType { get; set; }
        public int PrizingId { get; set; }
        public Prizing Prizing { get; set; }
    }
}
