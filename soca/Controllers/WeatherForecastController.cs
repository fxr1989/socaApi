using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using soca.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        public WeatherForecastController(SocaContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tenanta = db.Tenant.ToList();
            return Ok(tenanta);
        }
    }
}
