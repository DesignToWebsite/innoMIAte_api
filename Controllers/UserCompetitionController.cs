
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserCompetitionController(UserCompetitionService userCompetitionService) : ControllerBase
{
    private readonly UserCompetitionService _userCompetitionService = userCompetitionService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserCompetition(int id, [FromQuery] bool info = false)
    {
        var userCompetition = await _userCompetitionService.GetUserCompetition(id, info);
        if(userCompetition == null)
        {
            return NotFound();
        }
        return Ok(userCompetition);
    }

    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetCompetitionsByUserId(int userId)
    {
        var competitions = await _userCompetitionService.GetCompetitionsByUserId(userId);
        return Ok(competitions);
    }

    [HttpGet("competitions/{CompetitionId}")]
    public async Task<IActionResult> GetUsersByCompetitionId(int CompetitionId)
    {
        var users = await _userCompetitionService.GetUsersByCompetitionId(CompetitionId);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserCompetition(UserCompetitionDto userCompetitionDto)
    {
        var createdUserCompetition = await _userCompetitionService.AddUserToCompetition(userCompetitionDto);
        return CreatedAtAction(
            nameof(GetUserCompetition),
            new {id = createdUserCompetition.Id},
            createdUserCompetition
        );
    }

}