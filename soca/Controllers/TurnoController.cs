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
    public class TurnoController: BaseController
    {
        public ITurnoServicio Servicio { get; set; }
        public TurnoController(SocaContext context): base(context)
        {
            Servicio = new TurnoServicio(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listaTurnos = Servicio.ObtenerTodos();
            return Ok(listaTurnos);
        }
        [HttpPost]
        public IActionResult Agregar(Turno agregarTurno)
        {
            var nuevoTurno = Servicio.Agregar(agregarTurno);
            return Ok(nuevoTurno);
        }
        [HttpPut]
        public IActionResult Actualizar(Turno actualizarTurno)
        {
            var turnoActualizado = Servicio.Actualizar(actualizarTurno);
            return Ok(turnoActualizado);

        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            Servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }
    }
}
