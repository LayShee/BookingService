using BookingService.Dto;
using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookingService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public UserController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("get/{id}")]
        public async Task<UserInfoDto> GetById(int id)
        {
            var result = await _userService.GetAllInfoById(id);

            return result;
        }
    }
}
