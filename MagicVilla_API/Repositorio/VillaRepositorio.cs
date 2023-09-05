
using MagicVilla_API.Datos;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;

namespace MagicVilla_API.Repositorio
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {

        private readonly AppDBContext ctx;
        public VillaRepositorio(AppDBContext db) : base(db)
        {
            this.ctx = db;
        }
        public async Task<Villa> Actualizar(Villa villa)
        {
            villa.FechaActualizacion=DateTime.Now;
            this.ctx.Update(villa);
            await this.ctx.SaveChangesAsync();
            return villa;
            
        }
    }
}