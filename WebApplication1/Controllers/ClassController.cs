using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ClassService _classService;
        public ClassController(ClassService classService)
        {
            _classService = classService;
        }
        [HttpGet("get")]
        public async Task<List<Classes>> GetAll()
        {
            var result = await _classService.GetAll();

            return result;
        }
    }
}
