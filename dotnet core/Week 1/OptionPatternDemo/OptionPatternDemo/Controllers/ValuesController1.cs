using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPatternDemo.Settings;

namespace OptionPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private readonly DatabaseSettings _databaseSettings;

        public ValuesController1(IOptionsSnapshot<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        [HttpGet("GetLatestConfig")]
        public IActionResult Get()
        {
            return Ok(_databaseSettings);
        }
    }
}
