using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace INNOMIATE_API.Services;

public class UserService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(int id, bool compInfo)
    {
        // var userInfo = _context.Users.FindAsync(id);
        // var userInfo = _context.Users
        //     .Include(u=>u.ParticipatedCompetitions)
        //     .ThenInclude(pc => pc.Competition)
        //     .FirstOrDefaultAsync(u=> u.Id == id);

        // return await userInfo;
        IQueryable<User> query = _context.Users.Where(u=>u.Id == id);
        if(compInfo){
            query = query
                .Include(c=>c.ParticipatedCompetitions)
                .ThenInclude(u=>u.Competition);
        }
        return await query.FirstOrDefaultAsync();
        }

    public async Task<User> CreateUser(UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
            Email = userDto.Email,
            Bio = userDto.Bio,
            Password = userDto.Password,
            Location = userDto.Location,
            Website = userDto.Website,
            Github = userDto.Github,
            Linkedin = userDto.Linkedin,
            Image = userDto.Image,
            Skills = userDto.Skills,
            Interests = userDto.Interests,
            Followers = userDto.Followers,
            Following = userDto.Following,
            IsAcceuil = userDto.IsAcceuil,
            Likes = userDto.Likes
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> UpdateUser(int id, UserDto userDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        // Update properties
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.UserName = userDto.UserName;
        user.Email = userDto.Email;
        user.Bio = userDto.Bio;
        user.Location = userDto.Location;
        user.Website = userDto.Website;
        user.Github = userDto.Github;
        user.Linkedin = userDto.Linkedin;
        user.Image = userDto.Image;
        user.Skills = userDto.Skills;
        user.IsAcceuil = userDto.IsAcceuil;
        user.Interests = userDto.Interests;
        user.Followers = userDto.Followers;
        user.Following = userDto.Following;
        user.Likes = userDto.Likes;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> AuthenticateUser(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        return user;
    }
}
