using Dto.Autenticacion;
using Modelos;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IUsuarioServicio
    {
        Task<UsuarioTokenDto> Registrar(UsuarioRegistrarDto usuarioRegistrar);
        Task<UsuarioTokenDto> Login(UsuarioLogin usuarioLogin);
    }
}
