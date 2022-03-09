using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contratos
{
    public interface IErrorServicio
    {
        public bool TieneError();
        public string ObtenerError();
        public void AgregarError(string error);
    }
}
