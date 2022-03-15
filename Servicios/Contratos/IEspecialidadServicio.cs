using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IEspecialidadServicio
    {
        IQueryable<Especialidad>ObtenerTodos();
        Especialidad Agregar(Especialidad especialidad);
        Especialidad Actualizar(Especialidad especialidad);
        Especialidad Eliminar(int id);
    }
}
