using AppSettings.Models;
using AppSettings.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppSettings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IOptions<Config> _configuration;
        private readonly IConfigManager _configManager;

        public SettingsController(IOptions<Config> configuration, IConfigManager configManager)
        {
            _configuration = configuration;
            _configManager = configManager;
        }

        [HttpGet]
        public IActionResult GetSettings()
        {
            var data = _configuration.Value;
            return Ok(data);
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            var setting = _configManager.Test();
            return Ok(setting);
        }

        [HttpGet("Connector")]
        public async Task< IActionResult> DBConnector()
        {
            var setting = await _configManager.TestDBConnector();
            return Ok(setting);
        }
    }
}
