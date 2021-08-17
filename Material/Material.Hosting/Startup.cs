using Material.Application;
using Material.Business;
using Material.Core;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb.Configurations;
using Material.WebApi.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Material.Hosting
{
    public class Startup
    {
        protected readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options =>
                    {
                        options.EnableEndpointRouting = false;
                        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen();

            services
                .RegisterApplicationResourceDependencies()
                .RegisterBusinessResourceDependencies()
                .RegisterCoreDependencies();

            services.Configure<DocumentStoreConfiguration>(Configuration.GetSection("DocumentStoreConfiguration"));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

