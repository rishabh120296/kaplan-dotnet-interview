using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebApiTest.Data;

namespace WebApiTest.Web
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var host = CreateHostBuilder( args ).Build();

            using ( var scope = host.Services.CreateScope() )
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TestDbContext>();

                DataGenerator.Initialize( services );
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder( string[] args )
        {
            return Host.CreateDefaultBuilder( args )
                       .ConfigureWebHostDefaults( webBuilder => { webBuilder.UseStartup<Startup>(); } );
        }
    }
}
