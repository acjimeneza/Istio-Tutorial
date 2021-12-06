using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ms_istio.Infrastructure;

namespace Ms_istio.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rng = new Random();
            var result = await Task.FromResult<TimeDto>( new TimeDto
            {
                Date = DateTime.Now,
                Number = rng.Next(0, 55)
            });
            DataManager.SaveData(result);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var rng = new Random();
            var result = await Task.FromResult<List<TimeDto>>( DataManager.GetData());
            return Ok(result);
        }

    }
}
