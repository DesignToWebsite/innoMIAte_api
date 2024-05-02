using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models;
public class UserCompetition
{
    [Key]
    public int Id {get; set;}

    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User? User { get; set; }


    [ForeignKey("Competition")]
    public int CompetitionId { get; set; }
    public virtual Competition? Competition { get; set; }


    [Required]
    public required string Role { get; set; }
}

