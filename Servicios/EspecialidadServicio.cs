using Data;
using Modelos;
using Repositorios;
using Repositorios.Contratos;
using Servicios.Contratos;
using System.Linq;


namespace Servicios
{
    public class EspecialidadServicio : IEspecialidadServicio
    {
        public IRepositorioGenerico<Especialidad> RepositorioEspecialidad { get; set; }
        public EspecialidadServicio(SocaContext contexto)
        {
            RepositorioEspecialidad = new RepositorioGenerico<Especialidad>(contexto);
        }
        public IQueryable<Especialidad> ObtenerTodos()
        {
            return RepositorioEspecialidad.ObtenerTodos();
        }

        public Especialidad Agregar(Especialidad especialidad)
        {
            var nuevaEspecialidad = RepositorioEspecialidad.Agregar(especialidad);
            RepositorioEspecialidad.Guardar();
            return nuevaEspecialidad;
        }

        public Especialidad Actualizar(Especialidad especialidad)
        {
            var especialidadActualizada = RepositorioEspecialidad.Actualizar(especialidad);
            RepositorioEspecialidad.Guardar();
            return especialidadActualizada;
        }

        public Especialidad Eliminar(int id)
        {
            var especialidadEliminada = RepositorioEspecialidad.EliminarPorId(id);
            RepositorioEspecialidad.Guardar();
            return especialidadEliminada;
        }
    }
}
