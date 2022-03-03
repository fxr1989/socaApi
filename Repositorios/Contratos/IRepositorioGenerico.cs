using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorios.Contratos
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T ObtenerPorId(int id);
        T Agregar(T modelo);
        T Actualizar(T modelo);
        T EliminarPorId(int id);
        IQueryable<T> ObtenerFiltro(Expression<Func<T, bool>> filtro);
        IQueryable<T> ObtenerTodos();
    }
}
