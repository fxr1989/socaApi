using Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ErrorServicio : IErrorServicio
    {
        private List<string> Error { get; set; }

        public ErrorServicio()
        {
            Error = new List<string>(30);
        }

        public bool TieneError() => Error.Any();

        public string ObtenerError() => string.Join("\n", Error);

        public void AgregarError(string error) => Error.Add(error);
    }
}
