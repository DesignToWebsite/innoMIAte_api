using INNOMIATE_API.Data;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace INNOMIATE_API.Services;

public class PrizeService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Prize> AddPrizeToCompetition(PrizeDto prizeDto)
    {
        var prize = new Prize
        {
            Price = prizeDto.Price,
            Others = prizeDto.Others,
            Title = prizeDto.Title,
            Description = prizeDto.Description,
            ImageUrl = prizeDto.ImageUrl
        };

        _context.Prizes.Add(prize);
        await _context.SaveChangesAsync();
        return prize;

    }

    public async Task<bool> DeletePrize(int id)
    {
        var task = await _context.Prizes
            .FirstOrDefaultAsync(t=>t.Id == id);

        if(task != null){
            _context.Prizes.Remove(task);
            await _context.SaveChangesAsync();
        }
        return true;
    }

    public async Task<IEnumerable<Prize?>> GetPrizesByCompetition(int idCompetition){
        return await _context.Prizes
            .Where(p => p.CompetitionId == idCompetition)
            .ToListAsync();
    }

    public async Task<IEnumerable<Prize?>> GetPrizes(){
        return await _context.Prizes.ToListAsync();
    }

}
