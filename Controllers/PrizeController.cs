
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Models;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrizeController(PrizeService prizeService) : ControllerBase
{
    private readonly PrizeService _prizeService = prizeService;

    [HttpGet]
    public async Task<IActionResult> GetPrizes()
    {
        var prizes = await _prizeService.GetPrizes();
        return Ok(prizes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrizesByCompetition(int id)
    {
        var prizes = await _prizeService.GetPrizesByCompetition(id);
        if(prizes == null){
            return NotFound();
        }
        return Ok(prizes);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrizeToCompetition(PrizeDto prizeDto)
    {
        var createdPrize = await _prizeService.AddPrizeToCompetition(prizeDto);
        return CreatedAtAction(
            nameof(GetPrizes),
            new {id = createdPrize.Id},
            createdPrize
        );
    }
}
