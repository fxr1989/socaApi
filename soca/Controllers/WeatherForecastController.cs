using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;
using soca.Controllers.Base;
using System.Linq;

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

        //[HttpGet]
        //public IActionResult GetById(int id)
        //{
        //    var tenanta = db.Tenant.AsNoTracking().FirstAsync(x => x.Id == id);
        //    return Ok(tenanta);
        //}

        [HttpPost]
        public IActionResult Post(Tenant tenant)  
        {
            db.Tenant.Add(tenant);
            db.SaveChanges();
            return Ok(tenant);
        }

        [HttpPut]
        public IActionResult Put(int id,Tenant tenant)
        {
            db.Entry(tenant).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(tenant);
        }
    }
}
