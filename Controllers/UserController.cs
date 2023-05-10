using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace attendaceAppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto userForRegistrationDto)
        {
            // Check if user already exists
            if (await _userRepository.UserExists(userForRegistrationDto.Username))
                return BadRequest("Username already exists");

            // Create new user object
            var user = new User
            {
                Username = userForRegistrationDto.Username,
                RoleId = userForRegistrationDto.RoleId
            };

            // Register user with repository
            var registeredUser = await _userRepository.Register(user, userForRegistrationDto.Password);

            // Return successful response
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userForLoginDto)
        {
            // Check if user exists
            var user = await _userRepository.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            // Generate JWT token
            var token = await _userRepository.GenerateJwtToken(user);

            // Return token as response
            return Ok(new { token });
        }
    }
}
