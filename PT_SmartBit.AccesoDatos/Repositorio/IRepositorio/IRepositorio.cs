using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> Obtener(int Id);

        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true);

        Task<T> ObtenerPrimero(
            string incluirPropiedades = null,
            bool isTracking = true
            );

        Task Agregar(T entidad);

        void Remover(T entidad);

        void RemoverRango(IEnumerable<T> entidad);
    }
}
