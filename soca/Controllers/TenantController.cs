using soca.Controllers.Base;
using Data;
using Microsoft.AspNetCore.Mvc;
using Servicios.Contratos;
using Servicios;

namespace soca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : BaseController
    {
        public ITenantServicio Servicio { get; set; }

        public TenantController(SocaContext context) : base(context)
        {
            Servicio = new TenantServicio(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resultado = Servicio.ObtenerTodos();
            return Ok(resultado);
        }
    }
}
