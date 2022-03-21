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
    public class BloqueServicio : IBloqueServicio
    {
        public IRepositorioGenerico<Bloque> RepositorioBloque { get; set; }
        public BloqueServicio(SocaContext contexto)
        {
            RepositorioBloque = new RepositorioGenerico<Bloque>(contexto);
        }
        public Bloque Actualizar(Bloque bloque)
        {
            var bloqueActualizado = RepositorioBloque.Actualizar(bloque);
            RepositorioBloque.Guardar();
            return bloqueActualizado;
        }

        public Bloque Agregar(Bloque bloque)
        {
            var nuevoBloque = RepositorioBloque.Agregar(bloque);
            RepositorioBloque.Guardar();
            return nuevoBloque;
        }

        public Bloque Eliminar(int id)
        {
            var bloqueEliminado = RepositorioBloque.EliminarPorId(id);
            RepositorioBloque.Guardar();
            return bloqueEliminado;
        }

        public IQueryable<Bloque> ObtenerTodo()
        {
            return RepositorioBloque.ObtenerTodos();
        }
    }
}
