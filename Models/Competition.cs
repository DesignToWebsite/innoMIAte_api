namespace INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations;

public class Competition{
    [Key]
    public int Id { get; set; } 
    public required string Image { get; set;} 
    public required string Title { get; set;} 
    public required DateTime StartDate {get; set;}
    public required DateTime DeadLine {get; set;}
    public required DateTime LastModified {get; set;}
    public required string Location {get; set;}
    public required string DescriptionTop {get; set;} 
    public required string OverviewDescription {get; set;} 
    public required List<Prizes> Prizes {get; set;}
    public required List<string> Theme {get; set;}
    public required List<string> Tags {get; set;}

    public virtual ICollection<UserCompetition> UserCompetitions {get; set;} = new List<UserCompetition>();
    
    // Navigation property for the many-to-many relationship with Competitions
}