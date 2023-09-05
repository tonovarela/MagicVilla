using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }


        public DbSet<Villa> Villas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<NumeroVilla> NumeroVillas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                            new Villa()
                            {
                                Id = 1,
                                Nombre = "Villa 1",
                                Detalle = "Detalle de la villa",
                                ImagenURL = "",
                                Ocupantes = 5,
                                MetrosCuadrados = 200,
                                Amenidad = "",
                                FechaCreacion = DateTime.Now,
                                FechaActualizacion = DateTime.Now
                            },
                            new Villa()
                            {
                                Id = 2,
                                Nombre = "Villa 2",
                                Detalle = "Detalle de la villa 2",
                                ImagenURL = "",
                                Ocupantes = 4,
                                MetrosCuadrados = 100,
                                Amenidad = "",
                                FechaCreacion = DateTime.Now,
                                FechaActualizacion = DateTime.Now
                            }
                            );

        }

    }
}