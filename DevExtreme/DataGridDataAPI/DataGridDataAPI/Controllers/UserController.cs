using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataGridDataAPI.Repository;

namespace DataGridDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new UserRepository().Users;

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(Users);
        }
    }
}
