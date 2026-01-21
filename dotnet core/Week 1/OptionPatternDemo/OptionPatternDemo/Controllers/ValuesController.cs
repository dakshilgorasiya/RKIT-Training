using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPatternDemo.Settings;

namespace OptionPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DatabaseSettings _databaseSettings;

        public ValuesController(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        [HttpGet("GetDatabaseConfig")]
        public IActionResult Get()
        {
            return Ok(_databaseSettings);
        }
    }
}
