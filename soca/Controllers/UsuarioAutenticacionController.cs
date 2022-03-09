using Dto.Autenticacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Servicios;
using Servicios.Contratos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace soca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAutenticacionController : Controller
    {
        private readonly IErrorServicio errorServicio;
        private readonly IUsuarioServicio usuarioServicio;

        public UsuarioAutenticacionController(
            UserManager<Usuario> userManager,
            IOptionsMonitor<JwtConfiguracion> optionsMonitor,                                                     
            IErrorServicio helperError)
        {
            errorServicio = helperError;
            usuarioServicio = new UsuarioServicio(userManager, optionsMonitor.CurrentValue, errorServicio);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistrarDto usuarioRegistrar) 
        {
            var resultado = await usuarioServicio.Registrar(usuarioRegistrar);
            if(errorServicio.TieneError()) return BadRequest(errorServicio.ObtenerError());
            return Ok(resultado);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin usuarioLogin)
        {
            var resultado = await usuarioServicio.Login(usuarioLogin);
            if (errorServicio.TieneError()) return BadRequest(errorServicio.ObtenerError());
            return Ok(resultado);
        }

        
    }
}