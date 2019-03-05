using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FishWaters.Data;

namespace FishWaters
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
                    var context = services.GetRequiredService<FishWaterDbContext>();

                    // With ASP.NET Core 2.0 this is how the seed data initializer class is now called
                    // See also: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro#add-code-to-initialize-the-database-with-test-data
                    //
                    // and/or:  http://www.locktar.nl/programming/net-core/seed-database-users-roles-dotnet-core-2-0-ef/

                    SeedDataInitializer seedDataInitializer = new SeedDataInitializer(context);
                    seedDataInitializer.Seed();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            host.Run();






        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
