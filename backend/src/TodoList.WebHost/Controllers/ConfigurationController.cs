using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebHost.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ConfigurationController:ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ConfigurationController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Info()
        {
            return Ok(new
            {
                name = _environment.ApplicationName,
                environment = _environment.EnvironmentName 
            });
        }
    }
}