using System.ComponentModel.DataAnnotations.Schema;
using innomiate_api.Models;
using innoMIAte_api.Models;

namespace INNOMIATE_API.Models
{
    public class CompetitionParticipant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
        public User User { get; set; }
        public Competition Competition { get; set; }

        public int?  GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }



        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public bool IsLeader { get; set; }
        
    }
}
