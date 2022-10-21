using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Bussiness;
using API_Hospital_Boca.Models.dto;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MariaDB.Extensions;

namespace API_Hospital_Boca
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
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API-Hospital Boca", Version = "v1" });
            });

            services.AddDbContext<API_Hospital_Boca.Models.hospital_bocaContext>(options => {
                var connectionString = Configuration.GetConnectionString("HospitalBocaConnectionString");
                options.UseMySQL(connectionString);
            });

            // Aplica las politicas para los usuarios.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("WritePermission", policy => policy.RequireClaim("CanWrite", "true"));
                options.AddPolicy("ReadPermission", policy => policy.RequireClaim("CanRead", "true"));
            });

            services.AddScoped<IServicePacientes, ServicePacientes>();
            services.AddScoped<IServiceDoctores, ServiceDoctores>();
            services.AddScoped<IServiceHospitales, ServiceHospitales>();
            services.AddScoped<IServiceHistoriaClinica, ServiceHistoriaClinica>();
            services.AddScoped<IServiceCatalogos, ServiceCatalogos>();
            services.AddScoped<IServiceFichaIdentificacion, ServiceFichaIdentificacion>();
            services.AddScoped<IServicePersonalConsejeria, ServicePersonalConsejeria>();
            services.AddScoped<IServiceEncuestaSeguimeinto, ServiceEncuestaSeguimeinto>();
            services.AddScoped<IServiceNotaMedica, ServiceNotaMedica>();

            services.AddControllers();

            // Hora de usar JWT.
            var jwtSection = Configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSection.Get<JwtSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.Configure<JwtSettings>(jwtSection);

            services.AddCors(options =>
            {
               options.AddPolicy ("MY_CORS", builder =>
               {
                   builder.WithOrigins ("http://localhost:3000");
                   builder.AllowAnyMethod ();
                   builder.AllowAnyHeader ();
               });
            });

            services.AddControllers();

            services.AddScoped<IServicePacientes, ServicePacientes>();
            services.AddScoped<IServiceDoctores, ServiceDoctores>();
            services.AddScoped<IServiceHospitales, ServiceHospitales>();
            services.AddScoped<IServiceHistoriaClinica, ServiceHistoriaClinica>();
            services.AddScoped<IServiceCatalogos, ServiceCatalogos>();
            services.AddScoped<IServiceFichaIdentificacion, ServiceFichaIdentificacion>();
            services.AddScoped<IServicePersonalConsejeria, ServicePersonalConsejeria>();
            services.AddScoped<IServiceEncuestaSeguimeinto, ServiceEncuestaSeguimeinto>();
            services.AddScoped<IServiceNotaMedica, ServiceNotaMedica>();
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
            app.UseCors("MY_CORS");

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.jason", "API-Hospital Boca");
            });
        }
    }
}
