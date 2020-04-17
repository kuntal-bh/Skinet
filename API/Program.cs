using System;
using System.Threading.Tasks;
using infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           using(var scope = host.Services.CreateScope()) {              
               var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

               try {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    await context.Database.MigrateAsync();
                    await StoreSeedContext.SeedContextAsync(context,logger);
               }

               catch(Exception ex) {
                   var log = logger.CreateLogger<Program>();
                   log.LogError(ex,"An Error occured");
               }
           }
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
