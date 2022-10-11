using Data;
using Dto.Autenticacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Servicios.Contratos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        #region Dependencias
        private readonly UserManager<Usuario> userManager;
        private readonly JwtConfiguracion jwtConfiguracion;
        private readonly IErrorServicio errorServicio;
        private readonly SocaContext db;
        #endregion

        #region Constructor
        public UsuarioServicio(
            UserManager<Usuario> manager, 
            JwtConfiguracion jwt,
            IErrorServicio helperError,
            SocaContext context)
        {
            userManager = manager;
            jwtConfiguracion = jwt;
            errorServicio = helperError;
            db = context;
        }
        #endregion

        #region Metodos Publicos
        public async Task<UsuarioTokenDto> Registrar(UsuarioRegistrarDto usuarioRegistrar)
        {
            if (string.IsNullOrEmpty(usuarioRegistrar.Nombre)) errorServicio.AgregarError("Tiene que completar el nombre del usuario");
            if (string.IsNullOrEmpty(usuarioRegistrar.Apellido)) errorServicio.AgregarError("Tiene que completar el apellido del usuario");
            if (string.IsNullOrEmpty(usuarioRegistrar.Email)) errorServicio.AgregarError("Tiene que completar el email del usuario");
            if(!Regex.IsMatch(usuarioRegistrar.Email, @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")) errorServicio.AgregarError("El formato del correo es incorrecto");
            if (string.IsNullOrEmpty(usuarioRegistrar.Password)) errorServicio.AgregarError("Tiene que ingresar una contraseña");
            if (string.IsNullOrEmpty(usuarioRegistrar.UserName)) errorServicio.AgregarError("Tiene que ingresar un Nickname");
            if (string.IsNullOrEmpty(usuarioRegistrar.NombreTenant)) errorServicio.AgregarError("Tiene que ingresar el nombre de la entidad");
            if (errorServicio.TieneError()) return null;
            var nuevoUsuario = new Usuario()
            {
                Nombre = usuarioRegistrar.Nombre,
                Apellido = usuarioRegistrar.Apellido,
                Email = usuarioRegistrar.Email,
                UserName = usuarioRegistrar.UserName
            };
            var existeEmial = await userManager.FindByEmailAsync(usuarioRegistrar.Email);
            if (existeEmial != null) errorServicio.AgregarError($"El email {usuarioRegistrar.Email} ya se encuentra registrado");
            var existeTenant = await db.Tenant.AnyAsync(x => x.Nombre == usuarioRegistrar.NombreTenant);
            if (existeTenant) errorServicio.AgregarError("Esa entidad ya esta registrada");
            var nuevoTenant = new Tenant()
            {
                Nombre = usuarioRegistrar.NombreTenant,
                Descripcion = usuarioRegistrar.DescripcionTenant,
                Email = usuarioRegistrar.Email
            };
            var usuarioCreado = await userManager.CreateAsync(nuevoUsuario);
            db.Tenant.Add(nuevoTenant);
            if (errorServicio.TieneError()) return null;
            db.SaveChanges();
            var nuevoUsuarioTenant = new UsuarioTenant()
            {
                TenantId = nuevoTenant.Id,
                UsuarioId = nuevoUsuario.Id
            };
            db.UsuarioTenant.Add(nuevoUsuarioTenant);
            db.SaveChanges();
            var token = GenerateJwtToken(nuevoUsuario);
            return new UsuarioTokenDto 
            {
                Error = false,
                Token = token,
                TenantId = nuevoTenant.Id,
                UsuarioId = nuevoUsuario.Id
            };
        }

        public async Task<UsuarioTokenDto> Login(UsuarioLogin usuarioLogin)
        {
            if (string.IsNullOrEmpty(usuarioLogin.Email)) errorServicio.AgregarError("Tiene que completar el email del usuario");
            if (string.IsNullOrEmpty(usuarioLogin.Password)) errorServicio.AgregarError("Tiene que ingresar una contraseña");
            var usuarioExiste = await userManager.FindByEmailAsync(usuarioLogin.Email);
            if (usuarioExiste == null) errorServicio.AgregarError("Email no registrado");
            if (errorServicio.TieneError()) return null;
            var passwordCorrecto = await userManager.CheckPasswordAsync(usuarioExiste, usuarioLogin.Password);
            if (!passwordCorrecto) errorServicio.AgregarError("Password Incorrecto");
            if (errorServicio.TieneError()) return null;
            var tenant = db.UsuarioTenant.FirstOrDefault(x => x.UsuarioId == usuarioExiste.Id);
            if(tenant == null) errorServicio.AgregarError("Usuario no tiene asociado un tenant");
            var token = GenerateJwtToken(usuarioExiste);
            return new UsuarioTokenDto
            {
                Error = false,
                Token = token,
                TenantId = tenant.Id,
                UsuarioId  = usuarioExiste.Id
            };
        }

        #endregion

        #region Metodos Privados
        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfiguracion.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", usuario.Id),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
        #endregion
    }
}
