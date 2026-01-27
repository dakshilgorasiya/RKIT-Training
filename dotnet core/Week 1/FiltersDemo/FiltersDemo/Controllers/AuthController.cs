using FiltersDemo.Filters;
using FiltersDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = _jwtService.GenerateToken(userId: "1", role: "Admin");

            return Ok(new
            {
                accessToken = token
            });
        }

        [HttpGet("profile")]
        [ServiceFilter(typeof(JwtAuthorizeFilter))]
        public IActionResult Profile()
        {
            return Ok(new
            {
                message = "You are authorized!",
                data = "This is protected data"
            });
        }
    }
}
