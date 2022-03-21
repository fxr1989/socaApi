using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IBloqueServicio
    {
        IQueryable<Bloque> ObtenerTodo();
        Bloque Agregar(Bloque bloque);
        Bloque Actualizar(Bloque bloque);
        Bloque Eliminar(int id);

    }
}
