using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "plantMaterials", Version = "v1" });
            });
            services.AddDbContext<PlantMaterialsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCors(o =>
            {
                o.AddPolicy("MyCors", o =>
                {
                    o.WithOrigins("http://localhost:4200");
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowCredentials();
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(o =>
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "plantMaterials v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
