
using MagicVilla_API.Datos;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;

namespace MagicVilla_API.Repositorio
{
    public class NumeroVillaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {

   
      private readonly AppDBContext ctx;
        public NumeroVillaRepositorio(AppDBContext db) : base(db)
        {
            this.ctx = db;
        }
       
        public async Task<NumeroVilla> Actualizar(NumeroVilla numeroVilla)
        {
            numeroVilla.FechaActualizacion=DateTime.Now;
            this.ctx.Update(numeroVilla);
            await this.ctx.SaveChangesAsync();
            return numeroVilla;
        }
    }
}