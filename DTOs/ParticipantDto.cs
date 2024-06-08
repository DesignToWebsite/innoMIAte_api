using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace innomiate_api.DTOs
{
    public class ParticipantDto
    {
        public int ParticipantId { get; set; }
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
        public int? TeamId { get; set; }
        public bool IsLeader { get; set; }
    }
}
