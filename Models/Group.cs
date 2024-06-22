using innomiate_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models;


public class Group
{
    [Key]
    public int GroupId { get; set; }
    public string Name { get; set; } //Team name
    public string? Slogan { get; set; }
    public string? ProjectName { get; set; }
    public string? ProjectDescription { get; set; }
    public string? ProjectImage { get; set; }
    [ForeignKey("CompetitionId")]
    public int CompetitionId { get; set; }
    public ICollection<SubmittedInput> SubmittedInputs { get; set; }

    public Competition Competition { get; set; }

    public ICollection<CompetitionParticipant> Participants { get; set; }
    
}