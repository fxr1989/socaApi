using Data;
using Modelos;
using Repositorios;
using Repositorios.Contratos;
using Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PlanEstudioServicio : IPlanEstudioServicio
    {
        public IRepositorioGenerico<PlanEstudio> RepositorioPlanEstudio { get; set; }
        public PlanEstudioServicio(SocaContext contexto)
        {
            RepositorioPlanEstudio = new RepositorioGenerico<PlanEstudio>(contexto);
        }
        public PlanEstudio Actualizar(PlanEstudio planEstudio)
        {
            var planEstudioActualizado = RepositorioPlanEstudio.Actualizar(planEstudio);
            RepositorioPlanEstudio.Guardar();
            return planEstudioActualizado;
        }

        public PlanEstudio Agregar(PlanEstudio planEstudio)
        {
            var nuevoPlanEstudio = RepositorioPlanEstudio.Agregar(planEstudio);
            RepositorioPlanEstudio.Guardar();
            return nuevoPlanEstudio;
        }

        public PlanEstudio Eliminar(int id)
        {
            var planEstudioEliminado = RepositorioPlanEstudio.EliminarPorId(id);
            RepositorioPlanEstudio.Guardar();
            return planEstudioEliminado;
        }

        public IQueryable<PlanEstudio> ObtenerTodos()
        {
            return RepositorioPlanEstudio.ObtenerTodos();
        }
    }
}
