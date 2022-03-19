using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IPlanEstudioServicio
    {
        IQueryable<PlanEstudio> ObtenerTodos();
        PlanEstudio Agregar(PlanEstudio planEstudio);
        PlanEstudio Actualizar(PlanEstudio planEstudio);
        PlanEstudio Eliminar(int id);

    }
}
