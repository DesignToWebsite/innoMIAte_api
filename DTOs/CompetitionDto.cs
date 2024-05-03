
using INNOMIATE_API.Models;

namespace INNOMIATE_API.DTOs;

public class CompetitionDto{
    public int Id { get; set; } 
    
    public required string Image { get; set;} 
    public required string Title { get; set;} 
    public required DateTime StartDate {get; set;}
    public required DateTime DeadLine {get; set;}
    public required DateTime LastModified {get; set;}
    public required string Location {get; set;}
    public required string DescriptionTop {get; set;} 
    public required string OverviewDescription {get; set;} 
    public required List<string> Theme {get; set;}
    public required List<string> Tags {get; set;}

    public required string Rules {get; set;} 
    public required string Public {get; set;} 



}