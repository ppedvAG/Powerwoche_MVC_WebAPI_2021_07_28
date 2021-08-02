using ASPNETCORE_WEBAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           IHost host = CreateHostBuilder(args).Build();
           SeedDatabase(host);
           host.Run();
        }

        private static void SeedDatabase(IHost host)
        {
            IServiceScopeFactory scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                //Provider ist jetzt verfügbar!!!
                MovieDbContext ctx = scope.ServiceProvider.GetRequiredService <MovieDbContext> ();


                try
                {
                    SeedData.Init(ctx);
                }
                catch(Exception ex)
                {
                    ILogger logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Fehller beim befüllen der Datenbank");
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
