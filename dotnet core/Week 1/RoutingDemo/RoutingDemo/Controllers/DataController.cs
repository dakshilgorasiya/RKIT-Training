using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        //[Route("~/")]
        //[Route("/home")]
        //[Route("/home/index")]
        [HttpGet("[action]")]
        public IActionResult Home()
        {
            return Ok("HOME");
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            return Ok("Data");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody]string name)
        {
            return Ok(name);
        }

        [HttpGet("[action]/{id=5}")]
        public IActionResult actionResult(int id)
        {
            return Ok(id);
        }

        [HttpGet("multiPle/{id}/{city}/{country}")]
        public IActionResult multiple(int id, string city, string country)
        {
            return Ok(new { id, city, country });
        }

        [HttpGet("getiint/{id:int:min(4):max(7)}")]
        public IActionResult delete(int id)
        {
            return Ok(id);
        }

        [HttpGet("getString/{name:minlength(3)}")]
        public IActionResult getName(string name)
        {
            return Ok(name);
        }

        [HttpGet("getDate/{date:datetime}")]
        public IActionResult getDate(DateTime date)
        {
            return Ok(date);
        }
    }
}
