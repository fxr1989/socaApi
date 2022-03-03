using Data;
using Modelos;
using Repositorios;
using Repositorios.Contratos;
using Servicios.Contratos;
using System.Linq;

namespace Servicios
{
    public class TenantServicio : ITenantServicio
    {
        public IRepositorioGenerico<Tenant> RepositorioTenant { get; set; }

        public TenantServicio(SocaContext contexto)
        {
            RepositorioTenant = new RepositorioGenerico<Tenant>(contexto);
        }

        public IQueryable<Tenant> ObtenerTodos()
        {
            return RepositorioTenant.ObtenerTodos();
        }
    }
}
