using innomiate_api.Models;

namespace INNOMIATE_API.Models
{
    public class CompetitionParticipant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
        public User User { get; set; }
        public Competition Competition { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public bool IsLeader { get; set; }
        
    }
}
