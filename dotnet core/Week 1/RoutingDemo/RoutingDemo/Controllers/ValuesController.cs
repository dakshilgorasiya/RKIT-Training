using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    public class ValuesController : Controller
    {
        public IActionResult GetValue()
        {
            return Ok("value");
        }

        public IActionResult GetById(int id)
        {
            return Ok(new { id });
        }

        [HttpPost]
        public IActionResult GetMutltiple(string path)
        {
            return Ok(new { path });
        }
    }
}
