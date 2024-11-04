using BookingService.Dto;
using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;

        public PackageController(PackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("get")]
        public async Task<List<Packages>> GetAll()
        {
            var result = await _packageService.GetAll();

            return result;
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> PurchasePackage([FromBody] PackageIDDto packageId)
        {
            var result = await _packageService.PurchasePackage(packageId);
            return result ? Ok("Package purchased") : BadRequest("Purchase failed");
        }

        //[HttpPost("payment")]
        //public async Task<IActionResult> Payment([FromBody] PackageIDDto packageId)
        //{
        //    var result = await _packageService.PurchasePackage(packageId);
        //    return result ? Ok("Package purchased") : BadRequest("Purchase failed");
        //}
    }
}
