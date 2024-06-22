using INNOMIATE_API.DTOs;

namespace innomiate_api.DTOs
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImage { get; set; }
        public ICollection<CParticipantDTO>? Participants { get; set; }
    }

}
