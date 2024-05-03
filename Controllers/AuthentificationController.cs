using System.Threading.Tasks;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthenticationService authenticationService) : ControllerBase
{
    private readonly AuthenticationService _authService = authenticationService;

 

    // Endpoint to handle login requests
    [HttpGet("login")]
    public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
    {
        // Authenticate the user using the provided email and password
        var (user, errorMessage) = await _authService.AuthenticateUser(email, password);

        if (user == null)
        {
            // Return the custom error message if the email does not exist or password is incorrect
            return Unauthorized(errorMessage);
        }

        // Return user information on successful login (you can generate a JWT token here if needed)
        return Ok(user);
    }
}
