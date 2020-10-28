using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Juego> Juegos { get; set; }

        public DbSet<LetraIngresada> LetraIngresadas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Juego>()
                .HasData(
                    new Juego {
                        Id = 1,
                        Usuario = "Pepe",
                        Palabra = "automovil",
                        Modelo = "_ _ _ _ _ _ _ _ _",
                        CantIntentos = 6,
                        Puntaje = 0
                    }
                );
        }
    }
}
