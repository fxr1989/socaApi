using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Contratos;
using soca.Controllers.Base;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelos;


namespace soca.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadController : BaseController
    {
        public IFacultadServicio Servicio { get; set; }

        public FacultadController(SocaContext context) :base(context)
        {
            Servicio = new FacultadServicio(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listaFacultad = Servicio.ObtenerTodos();
            return Ok(listaFacultad);
        }

        [HttpPost]
        public IActionResult Agregar(Facultad agregarFacultad)
        {
            var nuevaFacultad = Servicio.Agregar(agregarFacultad);
            return Ok(nuevaFacultad);
        }
        [HttpPut]
        public IActionResult Actualizar(Facultad actualizaFacultad)
        {
            var facultadActualizada = Servicio.Actualizar(actualizaFacultad);
            return Ok(facultadActualizada);
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            
            Servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }

    }
}

