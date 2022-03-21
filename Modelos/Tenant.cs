using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }

        public ICollection<Facultad> Facultades { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }
        public ICollection<Turno> Turnos { get; set; }
        public ICollection<Bloque> Bloques { get; set; }
    }
}
