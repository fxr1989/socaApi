using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface ITurnoServicio
    {
        IQueryable<Turno> ObtenerTodos();

        Turno Agregar(Turno turno);

        Turno Actualizar(Turno turno);
        Turno Eliminar(int id);
    }
}
