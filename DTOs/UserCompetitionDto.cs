
using INNOMIATE_API.Models;

namespace INNOMIATE_API.DTOs;

public class UserCompetitionDto
{ 
    public int Id {get; set;}

    public int UserId { get; set; }

    public int CompetitionId { get; set; }
    


    public required string Role { get; set; }
}

