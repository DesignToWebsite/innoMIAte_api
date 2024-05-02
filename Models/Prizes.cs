using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models;

public class Prizes{
    [Key]
    public int Id {get; set;}
    public required string Price {get; set;}
    public List<string>? Others {get; set;}
    public required string Title {get; set;}
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    [ForeignKey("Competition")]
    public int CompetitionId {get; set;}
    public required virtual Competition Competition {get; set;}
    
}