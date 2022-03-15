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
    [Route ("api/[controller]")]
    [ApiController]
    public class EspecialidadController : BaseController
    {
        public IEspecialidadServicio Servicio { get; set; }

        public EspecialidadController(SocaContext context): base(context)
        {
            Servicio = new EspecialidadServicio(context);   
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listaEspecialidad = Servicio.ObtenerTodos();
            return Ok(listaEspecialidad);
        }
        [HttpPost]
        public IActionResult Agregar(Especialidad agregarEspecialidad)
        {
            var nuevaEspecialidad = Servicio.Agregar(agregarEspecialidad);
            return Ok(nuevaEspecialidad);
        }
        [HttpPut]
        public IActionResult Actualizar(Especialidad actualizarEspecialidad)
        {
            var especialidadActualizada = Servicio.Actualizar(actualizarEspecialidad);
            return Ok(especialidadActualizada);
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            Servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }

    }
}
