using Data;
using Modelos;
using Repositorios;
using Repositorios.Contratos;
using Servicios.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class FacultadServicio :IFacultadServicio
    {
        
        public IRepositorioGenerico<Facultad> RepositorioFacultad { get; set; }

        public FacultadServicio(SocaContext contexto)
        {
            RepositorioFacultad = new RepositorioGenerico<Facultad>(contexto);
           
        }
        public IQueryable<Facultad> ObtenerTodos()
        {
            return RepositorioFacultad.ObtenerTodos();
        }

        public Facultad Agregar(Facultad facultad)
        {
            
            var nuevaFacultad = RepositorioFacultad.Agregar(facultad);
            RepositorioFacultad.Guardar();
            return nuevaFacultad;

        }

        public Facultad Actualizar(Facultad facultad)
        {   
            var facultadActualizada = RepositorioFacultad.Actualizar(facultad);
            RepositorioFacultad.Guardar();
            return facultadActualizada;
        }

        public Facultad Eliminar(int id)
        {
            var facultadEliminada = RepositorioFacultad.EliminarPorId(id);
            RepositorioFacultad.Guardar();
            return facultadEliminada;
        }

    }
}
