using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    RefreshData(context).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        // This method refreshes store data every time our app starts.
        public static async Task RefreshData(DataContext context)
        {
            var juego = await context.Juegos.FindAsync(1);
            
            if (juego != null){
                
                juego.Id = 1;
                juego.Usuario = "Pepe";
                juego.Palabra = "automovil";
                juego.Modelo = "_ _ _ _ _ _ _ _ _";
                juego.CantIntentos = 6;
                juego.Puntaje = 0;
            }

            var letrasIngresadas = await context.LetraIngresadas.ToListAsync();
            
            context.LetraIngresadas.RemoveRange(letrasIngresadas);

            await context.SaveChangesAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
