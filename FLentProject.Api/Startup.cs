using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoreProject.Core.Interfaces.Apis;
using FLentProject.Infra.CrossCutting.Ioc;
using Microsoft.Extensions.Configuration;

namespace FLentProject.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            DependencyInjection.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostingEnvironmentHolder hostingEnvironmentHolder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            hostingEnvironmentHolder.ContentRootPath = env.ContentRootPath;

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                ));
        }
    }
}
