using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace INNOMIATE_API.Services;

public class CompetitionService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Competition>> GetAllCompetitions()
    {
        return await _context.Competitions.ToListAsync();

    }

    public async Task<Competition?> GetCompetitionById(int id)
    {
        var competition = await _context.Competitions
                    .FirstOrDefaultAsync(c => c.Id == id);
        if (competition == null)
        {

            throw new Exception($"Competition with ID {id} not found.");
        }
        return competition;
    }

    public async Task<Competition> CreateCompetition(CompetitionDto competitionDto)
    {
        var competition = new Competition
        {
            Image = competitionDto.Image,
            Title = competitionDto.Title,
            StartDate = competitionDto.StartDate,
            DeadLine = competitionDto.DeadLine,
            LastModified = DateTime.UtcNow,
            Location = competitionDto.Location,
            DescriptionTop = competitionDto.DescriptionTop,
            OverviewDescription = competitionDto.OverviewDescription,
            Prizes = competitionDto.Prizes,
            Theme = competitionDto.Theme,
            Tags = competitionDto.Tags
        };
        _context.Competitions.Add(competition);
        await _context.SaveChangesAsync();
        return competition;
    }

}