using System.Threading.Tasks;
using INNOMIATE_API.Models;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.DTOs;

namespace INNOMIATE_API.Services;

public class AuthenticationService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

 
    public async Task<(User?, string)> AuthenticateUser(string email, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            // User with the provided email not found
            return (null, "Email does not exist.");
        }

        // Verify the password (use a secure password hashing and comparison method)
        var passwordCorrect = user.Password == password ? true : false;
        if (passwordCorrect)
        {
            // Password is valid, return the user
            return (user, string.Empty);
        }

        // Password is invalid
        return (null, "Invalid password.");
    }

   

}
