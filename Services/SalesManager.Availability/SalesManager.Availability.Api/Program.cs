using Convey;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SalesManager.Availability.Application;
using System.Threading.Tasks;

namespace SalesManager.Availability.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
            .Build()
            .RunAsync();

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        => WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(services => 
            {
                services.AddControllers();

                services
                    .AddConvey()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build();
            })
            .Configure(app => 
            {
                app.UseInfrastructure();
                app.UseRouting()
                    .UseEndpoints(e => e.MapControllers());
            });


        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
