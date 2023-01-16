using API_Hospital_Boca.Bussiness;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Models.dto;
using API_Hospital_Boca.Services;
using ControlUsuarios.Repositories;
using ControlUsuarios.Repositories.Impl;
using ControlUsuarios.Services;
using ControlUsuarios.Services.Impl;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API-Hospital Boca", Version = "v1" });
});

builder.Services.AddDbContext<API_Hospital_Boca.Models.hospital_bocaContext>(options => {
    var connectionString = configuration.GetConnectionString("HospitalBocaConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
});

builder.Services.AddDbContext<ControlUsuarios.Models.userContext>(options => {
    var connectionString = configuration.GetConnectionString("HospitalUsuarioConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
});

builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();

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

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = false;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MY_CORS", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://ashy-meadow-08cbc3810.2.azurestaticapps.net");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("MY_CORS");

app.UseAuthentication();
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

app.Run();