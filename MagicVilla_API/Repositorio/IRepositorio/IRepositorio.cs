
using System.Linq.Expressions;


namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {


        Task Crear(T entidad);
        Task<List<T>> Listar(Expression<Func<T,bool>> filtro=null,string incluirPropiedades=null);
        
        Task<T> Obtener(Expression<Func<T,bool>> filtro=null,bool tracked=false, string incluirPropiedades =null);
       
        Task Eliminar(T entidad);
    }
}