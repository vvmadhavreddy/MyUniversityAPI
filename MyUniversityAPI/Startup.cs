using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using MyUniversityAPI.Models.DBSettings;
using MyUniversityAPI.Services;
using MyUniversityAPI.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using MyUniversityAPI.Filters;

namespace MyUniversityAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<UnivDeptsDBSettings>(Configuration.GetSection("UnivDepartmentsDB"));
            services.Configure<UnivStudsDBSettings>(Configuration.GetSection("UnivStudentsDB"));

            ResolveServiceDependencies(services);

            services.ConfigureCORS();

            services.AddControllersWithNewtonsoftJSON();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "University API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ResolveServiceDependencies(IServiceCollection services)
        {
            services.AddSingleton<DepartmentsService>();
            services.AddSingleton<StudentsService>();
            services.AddScoped<ModelValidationAttribute>();
        }
    }
}