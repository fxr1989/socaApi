using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Autenticacion
{
    public class UsuarioRegistrarDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string NombreTenant { get; set; }
        public string DescripcionTenant { get; set; }
    }
}
