using System;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GCCDockerWorkshop.Models;

namespace GCCDockerWorkshop
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            Task.Run(async () =>
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<GCCDockerWorkshopDB>();
                        await waitForDb(services);
                        context.Database.EnsureCreated();
                        context.Database.Migrate();
                        SeedData.Initialize(services);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred seeding the DB.");
                    }
                }
            }).Wait();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static async Task waitForDb(IServiceProvider services)
        {
            var maxAttemps = 12;
            var delay = 5000;

            for (int i = 0; i < maxAttemps; i++)
            {
                Console.WriteLine("Attempting to connect to database # " + i);
                
               
                if (ChekDatabaseConnectivity(services))
                {

                    return;
                }
                await Task.Delay(delay);
            }

            // after a few attemps we give up
            throw new Exception("Unable to connect to database ");
        }
        private static bool ChekDatabaseConnectivity(IServiceProvider services)
        {
            var context = services.GetRequiredService<GCCDockerWorkshopDB>();

            try
            {
                 context.Database.EnsureCreated();
                //Console.WriteLine(@"INFO: ConnectionString: " + context.Database.Connection.ConnectionString);
                return context.Database.CanConnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }


        }
    }
}
