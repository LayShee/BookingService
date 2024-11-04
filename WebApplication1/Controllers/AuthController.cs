using BookingService.Dto;
using BookingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public AuthController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto registrationDto)
        {
            var result = await _userService.RegisterUserAsync(registrationDto);

            if (!result)
            {
                return BadRequest("Registration failed.");
            }

            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.ValidateUser(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
