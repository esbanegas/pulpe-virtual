using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PulpeVirtual.Services.DataContext;

namespace PulpeVirtual.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            CreateDbIfNotExistis(host);

            host.Run();
        }

        private static void CreateDbIfNotExistis(IHost host){
            using(var scope = host.Services.CreateScope()){
                var services = scope.ServiceProvider;

                try{
                    var context = services.GetRequiredService<PulpeVirtualDataContext>();
                    // context.Database.EnsureCreated();

                    DbInitialize.Initialize(context);
       
                }catch (Exception ex){
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error al crear Base de Datos...");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
