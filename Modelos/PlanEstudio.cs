using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PlanEstudio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFin { get; set; }
        public int EspecialidadId { get; set; }
        public int TurnoId { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
