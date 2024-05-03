using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace INNOMIATE_API.Models;

public class Organizer
{
   
    public required string OrganizeName  { get; set; }
    public required string Image  { get; set; }
    public required string OrganizeType  { get; set; }
}