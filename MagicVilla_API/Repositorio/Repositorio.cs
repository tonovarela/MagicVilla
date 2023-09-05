using System.Linq.Expressions;
using MagicVilla_API.Datos;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
namespace MagicVilla_API.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

       private readonly AppDBContext _ctx;

        internal DbSet<T> dbSet;

        public Repositorio(AppDBContext db)
        {
            _ctx = db;
            dbSet = _ctx.Set<T>();
        }
        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Guardar();
        }

        public async Task Eliminar(T entidad)
        {
            dbSet.Remove(entidad);
            await Guardar();
        }

        private async Task Guardar()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task<List<T>> Listar(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro!= null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades!=null)  //El modelo debe de estar relacionado
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query= query.Include(incluirProp);
                }

            }
            return query.ToListAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> filtro=null, bool tracked = false, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked) { query = query.AsNoTracking(); }
            if (filtro != null) { query = query.Where(filtro); }
            if (incluirPropiedades != null)  //El modelo debe de estar relacionado
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }

            }
            return await query.FirstOrDefaultAsync();
        }
    }
    }