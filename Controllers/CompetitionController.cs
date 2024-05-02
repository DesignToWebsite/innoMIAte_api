using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompetitionController(CompetitionService competitionService) : ControllerBase
{
    private readonly CompetitionService _competitionService = competitionService;

    [HttpGet]
    public async Task<IActionResult> GetAllCompetitions()
    {
        var competitions = await _competitionService.GetAllCompetitions();
        return Ok(competitions);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetitionById(int id)
    {
        var competition = await _competitionService.GetCompetitionById(id);
        if (competition == null)
        {
            return NotFound();
        }
        return Ok(competition);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompetition(CompetitionDto competitionDto)
    {
        var createCompetition = await _competitionService.CreateCompetition(competitionDto);
        return CreatedAtAction(
            nameof(GetCompetitionById),
            new {id=createCompetition.Id},
            createCompetition
        );
    }
}

