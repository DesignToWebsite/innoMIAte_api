using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    
    private readonly UserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        var createdUser = await _userService.CreateUser(userDto);
        return CreatedAtAction(
            nameof(GetUserById), 
            new { id = createdUser.Id }, 
            createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
    {
        var updatedUser = await _userService.UpdateUser(id, userDto);
        if (updatedUser == null)
        {
            return NotFound();
        }
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
