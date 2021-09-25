using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainModel.Services.DependenciaService;
using DomainModel.Services.EmpleadoService;
using Repositories.RepositoryBase;
using Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi
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

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArquitecturaBackEnd_Local", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Servicios BackEnd ItoSoftware",
                    Description = "Descripcion Servicios",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "jonathanreatiga@",
                        Email = string.Empty,
                        //Url = new Uri(""),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        //Url = new Uri(""),
                    }
                });
            });

            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IDependenciaService, DependenciaService>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ItoSoftware");
                //c.RoutePrefix = string.Empty;
            });

        }
    }
}
