using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISettingsService _settingsService1;
        private readonly ISettingsService _settingsService2;
        private readonly IUserService _userService1;
        private readonly IUserService _userService2;
        private readonly IEmailService _emailService1;
        private readonly IEmailService _emailService2;

        public DataController(ISettingsService settingsService1, ISettingsService settingsService2, IUserService userService1, IUserService userService2, IEmailService emailService1, IEmailService emailService2)
        {
            _settingsService1 = settingsService1;
            _settingsService2 = settingsService2;
            _userService1 = userService1;
            _userService2 = userService2;
            _emailService1 = emailService1;
            _emailService2 = emailService2;
        }

        [HttpGet]
        [Route("appname")]
        public IActionResult GetAppName()
        {
            var name = _settingsService2.AppName;
            return Ok(_settingsService1.AppName);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers()
        {
            _userService2.GetUsers();
            return Ok(_userService1.GetUsers());
        }

        [HttpPost]
        [Route("Notify")]
        public IActionResult NotifyUser()
        {
            _emailService1.Send("HI");
            _emailService2.Send("Hello");
            return Ok();
        }
    }
}
