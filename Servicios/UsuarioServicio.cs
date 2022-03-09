using Dto.Autenticacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Servicios.Contratos;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        #endregion

        #region Constructor
        public UsuarioServicio(
            UserManager<Usuario> manager, 
            JwtConfiguracion jwt,
            IErrorServicio helperError)
        {
            userManager = manager;
            jwtConfiguracion = jwt;
            errorServicio = helperError;
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
            if(errorServicio.TieneError()) return null;
            var nuevoUsuario = new Usuario()
            {
                Nombre = usuarioRegistrar.Nombre,
                Apellido = usuarioRegistrar.Apellido,
                Email = usuarioRegistrar.Email,
                UserName = usuarioRegistrar.UserName
            };
            var usuarioCreado = await userManager.CreateAsync(nuevoUsuario);
            var token = GenerateJwtToken(nuevoUsuario);
            return new UsuarioTokenDto 
            {
                Error = false,
                Token = token,
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
            var token = GenerateJwtToken(usuarioExiste);
            return new UsuarioTokenDto
            {
                Error = false,
                Token = token,
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
