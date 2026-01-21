using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPatternDemo.Settings;

namespace OptionPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IOptionsMonitor<DatabaseSettings> _monitor;

        public DataController(IOptionsMonitor<DatabaseSettings> monitor)
        {
            _monitor = monitor;
        }

        [HttpGet("GetConfig")]
        public IActionResult Get()
        {
            return Ok(_monitor.CurrentValue);
        }
    }
}
