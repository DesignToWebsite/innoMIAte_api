using innomiate_api.Models;
using System.Globalization;

namespace INNOMIATE_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Github { get; set; }
        public string? Linkedin { get; set; }
        public string? Image { get; set; }
        public List<string>? Skills { get; set; }
        public List<string>? Interests { get; set; }
        public List<int>? Followers { get; set; }
        public List<int>? Following { get; set; }
        public List<int>? Likes { get; set; }

        //Navigation References 
        public virtual ICollection<CompetitionParticipant> ParticipatedCompetitions { get; set; }
        public virtual ICollection<CompetitionCoach> CoachedCompetitions { get; set; }
        public virtual ICollection<CompetitionJudge> JudgedCompetitions { get; set; }
        public virtual ICollection<CompetitionCreator> CreatedCompetitions { get; set; }
       // public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<HostingRequest> HostingRequests { get; set; }





    }
}
