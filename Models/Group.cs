using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using INNOMIATE_API.Models;

namespace innoMIAte_api.Models;

public class Group
{
    [Key]
    public int GroupId { get; set; }
    public string Name { get; set; } //Team name
    public string? Slogan { get; set; }
    public string? ProjectName { get; set; }
    public string? ProjectDescription { get; set; }
    public string? ProjectImage { get; set; }
    public int CompetitionId { get; set; }
    [ForeignKey("CompetitionId")]
    public Competition Competition { get; set; }

    public ICollection<CompetitionParticipant> Participants { get; set; }
}
