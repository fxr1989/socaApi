using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class UsuarioTenant
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int TenantId { get; set; }
        public Usuario Usuario { get; set; }
        public Tenant Tenant { get; set; }
    }
}
