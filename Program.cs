using API_Hospital_Boca.Bussiness;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Models.dto;
using API_Hospital_Boca.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.OpenApi.Models;

namespace API_Hospital_Boca
{
    public class Program
    {
        /*
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    if (new hospital_bocaContext() != null)
                    {
                        Console.WriteLine("Sirve");
                    }
                });
        */
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;
            configuration.AddEnvironmentVariables();

            // Aplica las politicas para los usuarios.
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("WritePermission", policy => policy.RequireClaim("CanWrite", "true"));
                options.AddPolicy("ReadPermission", policy => policy.RequireClaim("CanRead", "true"));
            });

            // Añade contexto de la base de datos.
            builder.Services.AddDbContext<hospital_bocaContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("HospitalBocaConnectionString");
                var version = ServerVersion.Parse("8.0.26-mysql");
                options.UseMySql(connectionString, version);
            });


            builder.Services.AddScoped<IServicePacientes, ServicePacientes>();
            builder.Services.AddScoped<IServiceDoctores, ServiceDoctores>();
            builder.Services.AddScoped<IServiceHospitales, ServiceHospitales>();
            builder.Services.AddScoped<IServiceHistoriaClinica, ServiceHistoriaClinica>();
            builder.Services.AddScoped<IServiceCatalogos, ServiceCatalogos>();
            builder.Services.AddScoped<IServiceFichaIdentificacion, ServiceFichaIdentificacion>();
            builder.Services.AddScoped<IServicePersonalConsejeria, ServicePersonalConsejeria>();
            builder.Services.AddScoped<IServiceEncuestaSeguimeinto, ServiceEncuestaSeguimeinto>();
            builder.Services.AddScoped<IServiceNotaMedica, ServiceNotaMedica>();

            builder.Services.AddControllers();

            // Hora de usar JWT.
            var jwtSection = builder.Configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSection.Get<JwtSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret);

            builder.Services.Configure<JwtSettings>(jwtSection);

            // Hora de agregar autenticacion.
            builder.Services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                // Cambiar en produccion!!
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    // Cambiar en produccion!!
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Esto son ajustes aplicables del header POST para Swagger, pero mientras
            // estara aqui para realizar la verificacion.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
