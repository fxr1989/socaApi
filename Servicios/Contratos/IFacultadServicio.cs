
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IFacultadServicio
    {
        IQueryable<Facultad> ObtenerTodos();
        
        Facultad Agregar(Facultad facultad);

        Facultad Actualizar(Facultad facultad);
        Facultad Eliminar(int id);
        

    }
}
