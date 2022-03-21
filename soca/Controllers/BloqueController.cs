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
    public class BloqueController: BaseController
    {
        public IBloqueServicio Servicio { get; set; }
        public BloqueController(SocaContext context): base(context)
        {
            Servicio = new BloqueServicio(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listaBloque = Servicio.ObtenerTodo();
            return Ok(listaBloque);
        }
        [HttpPost]
        public IActionResult Agregar(Bloque agregarBloque)
        {
            var nuevoBloque = Servicio.Agregar(agregarBloque);
            return Ok(nuevoBloque);
        }
        [HttpPut]
        public IActionResult Actualizar(Bloque actualizarBloque)
        {
            var bloqueActualizado = Servicio.Actualizar(actualizarBloque);
            return Ok(bloqueActualizado);
        }
        public IActionResult Eliminar(int id)
        {
            Servicio.Eliminar(id);
            return Ok("Bloque Eliminado Correctamente");
        }

    }
}
