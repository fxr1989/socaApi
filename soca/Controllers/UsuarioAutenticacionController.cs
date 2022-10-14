using Data;
using Dto.Autenticacion;
using Dto.Error;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAutenticacionController : Controller
    {
        private readonly IErrorServicio errorServicio;
        private readonly IUsuarioServicio usuarioServicio;

        public UsuarioAutenticacionController(
            UserManager<Usuario> userManager,
            IOptionsMonitor<JwtConfiguracion> optionsMonitor,                                                     
            IErrorServicio helperError,
            SocaContext context)
        {
            errorServicio = helperError;
            usuarioServicio = new UsuarioServicio(userManager, optionsMonitor.CurrentValue, errorServicio, context);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistrarDto usuarioRegistrar) 
        {
            var resultado = await usuarioServicio.Registrar(usuarioRegistrar);
            if (errorServicio.TieneError()) return BadRequest(new ErrorRequest { Error = true, Mensaje = errorServicio.ObtenerError() });
            return Ok(resultado);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin usuarioLogin)
        {
            var resultado = await usuarioServicio.Login(usuarioLogin);
            if (errorServicio.TieneError()) return BadRequest(new ErrorRequest { Error = true, Mensaje = errorServicio.ObtenerError() });
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}