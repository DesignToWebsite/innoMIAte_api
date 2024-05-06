using INNOMIATE_API.Models;

namespace innomiate_api.Models.Badging
{
    public class Badging
    {
        public int BadgingId { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public ICollection<Badge> Badges { get; set; }
    }
}
