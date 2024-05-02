using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace INNOMIATE_API.Services;

public class UserCompetitionService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    // Add a user to a competition
    public async Task<UserCompetition> AddUserToCompetition(UserCompetitionDto userCompetitionDto)
    {
        // Create a new UserCompetition record
        var userCompetition = new UserCompetition
        {
            UserId = userCompetitionDto.UserId,
            CompetitionId = userCompetitionDto.CompetitionId,
            Role = userCompetitionDto.Role
        };

        // Add the record to the database and save changes
        _context.UserCompetitions.Add(userCompetition);
        
        await _context.SaveChangesAsync();
        return userCompetition;
    }

    // Remove a user from a competition
    public async Task<bool> RemoveUserFromCompetition(int userId, int competitionId)
    {
        // Find the UserCompetition record
        var userCompetition = await _context.UserCompetitions
            .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CompetitionId == competitionId);


        // If the record exists, remove it and save changes
        if (userCompetition != null)
        {
            _context.UserCompetitions.Remove(userCompetition);
            await _context.SaveChangesAsync();
        }
        return true;
    }

    // Get competitions a user is participating in
    public async Task<IEnumerable<Competition?>> GetCompetitionsByUserId(int userId)
    {
        return (IEnumerable<Competition?>)await _context.UserCompetitions
            .Where(uc => uc.UserId == userId)
            .Select(uc => uc.CompetitionId)
            .ToListAsync();
    }

    // Get users participating in a competition
    public async Task<IEnumerable<User?>> GetUsersByCompetitionId(int competitionId)
    {
        return (IEnumerable<User?>)await _context.UserCompetitions
            .Where(uc => uc.CompetitionId == competitionId)
            .Select(uc => uc.UserId)
            .ToListAsync();
    }

    public async Task<UserCompetition?> GetUserCompetition(int id, bool includeRelated = false)
    {
        // Query to get the UserCompetition

        // Query the database to find the UserCompetition record matching the given UserId and CompetitionId
        // var userCompetition = await _context.UserCompetitions.FindAsync(id);
        
        // return userCompetition;

        // Query to get the UserCompetition
        IQueryable<UserCompetition> query = _context.UserCompetitions.Where(uc => uc.Id == id);

        // Conditionally include related entities based on the includeRelated parameter
        if (includeRelated)
        {
            query = query
                .Include(uc => uc.User)          // Include User navigation property
                .Include(uc => uc.Competition);  // Include Competition navigation property
        }

        // Execute the query and return the result
        return await query.FirstOrDefaultAsync();
    }    
    
}
