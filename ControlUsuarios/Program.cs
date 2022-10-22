using System;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.MariaDB.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ControlUsuarios.Models;
using ControlUsuarios.Repositories;
using ControlUsuarios.Repositories.Impl;
using ControlUsuarios.Services;
using ControlUsuarios.Services.Impl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information);
});

builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();

// Add services to the container.

builder.Services.AddDbContext<userContext>(options =>
{
    var connectionString = configuration.GetConnectionString("HospitalBocaUsrConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
});

var jwtSection = builder.Configuration.GetSection("JwtSettings");
var jwtSettings = jwtSection.Get<JwtSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

builder.Services.Configure<JwtSettings>(jwtSection);

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = false;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
    };
});

//builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

