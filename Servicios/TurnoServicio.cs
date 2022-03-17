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
    public class TurnoServicio : ITurnoServicio
    {
        public IRepositorioGenerico<Turno> RepositorioTurno { get; set; }
        public TurnoServicio(SocaContext contexto)
        {
            RepositorioTurno = new RepositorioGenerico<Turno>(contexto);
        }
        public Turno Actualizar(Turno turno)
        {
            var turnoActualizado = RepositorioTurno.Actualizar(turno);
            RepositorioTurno.Guardar();
            return turnoActualizado;
        }

        public Turno Agregar(Turno turno)
        {
            var nuevoTurno = RepositorioTurno.Agregar(turno);
            RepositorioTurno.Guardar();
            return nuevoTurno;
        }

        public Turno Eliminar(int id)
        {
            var turnoEliminado = RepositorioTurno.EliminarPorId(id);
            RepositorioTurno.Guardar();
            return turnoEliminado;
        }

        public IQueryable<Turno> ObtenerTodos()
        {
            return RepositorioTurno.ObtenerTodos();
        }
    }
}
