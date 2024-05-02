using System.ComponentModel.DataAnnotations;
using INNOMIATE_API.Models;

namespace INNOMIATE_API.DTOs;

public class PrizesDto{
    public int Id {get; set;}
    public int CompetitionId {get; set;}
    public required string Price {get; set;}
    public List<string> Others {get; set;} = [];
    public required string Title {get; set;}
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

}