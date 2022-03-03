using Data;
using Repositorios.Contratos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected SocaContext db;

        public RepositorioGenerico(SocaContext context)
        {
            db = context;
        }

        public T Actualizar(T modelo)
        {
            db.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return modelo;
        }

        public T Agregar(T modelo)
        {
            db.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            return modelo;
        }

        public T EliminarPorId(int id)
        {
            var modelo = db.Set<T>().Find(id);
            db.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return modelo;
        }

        public T ObtenerPorId(int id)
        {
            var modelo = db.Set<T>().Find(id);
            return modelo;
        }

        public IQueryable<T> ObtenerFiltro(Expression<Func<T, bool>> filtro)
        {
            var modelos = db.Set<T>().Where(filtro);
            return modelos;
        }
        public IQueryable<T> ObtenerTodos()
        {
            var modelos = db.Set<T>();
            return modelos;
        }
    }
}
