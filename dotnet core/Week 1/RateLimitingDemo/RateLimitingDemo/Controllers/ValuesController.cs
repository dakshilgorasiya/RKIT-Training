using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("fixed")]
        [EnableRateLimiting("fixed")]
        public IActionResult Fixed()
        {
            return Ok("Fixed");
        }

        [HttpGet("sliding")]
        [EnableRateLimiting("sliding")]
        public IActionResult Sliding()
        {
            return Ok("Sliding");
        }

        [HttpGet("TokenBucket")]
        [EnableRateLimiting("tokenBucket")]
        public IActionResult TokenBucket()
        {
            return Ok("Token bucket");
        }

        [HttpGet("Concurrency")]
        [EnableRateLimiting("concurrency")]
        public async Task<IActionResult> Concurrency()
        {
            await Task.Delay(10000);
            return Ok("Concurrency");
        }
    }
}
