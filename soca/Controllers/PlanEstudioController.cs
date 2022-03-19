
using Data;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicios;
using Servicios.Contratos;
using soca.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanEstudioController : BaseController
    {
        public IPlanEstudioServicio Servicio { get; set; }
        public PlanEstudioController(SocaContext context): base(context)
        {
            Servicio = new PlanEstudioServicio(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listaPlanEstudio = Servicio.ObtenerTodos();
            return Ok(listaPlanEstudio);
        }
        [HttpPost]
        public IActionResult Agregar(PlanEstudio agregarPlanEstudio)
        {
            var nuevoPlanEstudio = Servicio.Agregar(agregarPlanEstudio);
            return Ok(nuevoPlanEstudio);

        }
        [HttpPut]
        public IActionResult Actualizar(PlanEstudio actualizarPlanEstudio)
        {
            var planEstudioActualizado = Servicio.Actualizar(actualizarPlanEstudio);
            return Ok(planEstudioActualizado);
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            Servicio.Eliminar(id);
            return Ok("Eliminado correctamente");
        }
    }
}
