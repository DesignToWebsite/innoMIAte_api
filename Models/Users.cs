using Microsoft.EntityFrameworkCore;
namespace INNOMIATE_API.Models
{
    public class User
    {
        public int Id {get; set;}
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public required string UserName {get; set;}
        public required string Email {get; set;}
        public string? Bio {get; set;}
        public string? Location {get; set;}
        public string? Website {get; set;}
        public string? Github {get; set;}
        public string? Linkedin {get; set;}
        public string? image {get; set;}
        public List<string>? Skills {get; set;}
        public List<string>? Interests {get; set;}

        public List<int>? Followers {get; set;}
        public List<int>? Following {get; set;}



    }

    class UserDb : DbContext
    {
        public UserDb(DbContextOptions options) : base(options){}
        public DbSet<User> Users {get; set;} =  null!;

    }
}