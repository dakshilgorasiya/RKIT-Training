using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ValuesController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Method way to resolve DI
        [HttpGet("GetUsers")]
        public IActionResult GetUser(IUserService userService)
        {
            return Ok(userService.GetUsers());
        }


        // ServiceProvider way to resolve DI
        [HttpGet("SendEmail")]
        public IActionResult SendEmail()
        {
            var emailService = _serviceProvider.GetService<IEmailService>();
            emailService.Send("HI");
            return Ok();
        }


        // ActivatorUtility to use DI
        [HttpGet("GetSettings")]
        public IActionResult GetSettings()
        {
            var userSetting = ActivatorUtilities.CreateInstance<SettingsService>(_serviceProvider);
            return Ok(userSetting.AppName);
        }
    }
}
