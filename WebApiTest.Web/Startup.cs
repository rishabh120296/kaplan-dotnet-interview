using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using WebApiTest.Data;
using WebApiTest.Services;

namespace WebApiTest.Web
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers();
            services.AddSwaggerGen( c => { c.SwaggerDoc( "v1", new OpenApiInfo { Title = "WebApiTest", Version = "v1" } ); } );

            services.AddDbContext<TestDbContext>( options =>
                                                      options.UseInMemoryDatabase( databaseName : "TestDB" ) );

            services.AddScoped<IOrderItemsService, OrderItemsService>();
            services.AddScoped<IOrderSummaryService, OrderSummaryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "WebApiTest v1" ) );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints => { endpoints.MapControllers(); } );
        }
    }
}
