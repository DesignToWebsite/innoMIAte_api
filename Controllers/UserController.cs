using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;
using INNOMIATE_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using innomiate_api.DTOs;

namespace INNOMIATE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

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
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] loginDto loginDto)
        {
            var user = await _userService.AuthenticateUser(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // Create a session for the authenticated user
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("FirstName", user.FirstName);
            HttpContext.Session.SetString("LastName", user.LastName);
 

            return Ok(user);
        }

        [HttpGet("UserSession")]
        public IActionResult GetUserSession()
        {
            var firstName = HttpContext.Session.GetString("FirstName");
            var lastName = HttpContext.Session.GetString("LastName");

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return NotFound();
            }

            var userSession = new { FirstName = firstName, LastName = lastName };

            return Ok(userSession);
        }
    }


}
