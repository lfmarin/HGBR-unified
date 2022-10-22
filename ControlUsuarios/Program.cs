using System;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.MariaDB.Extensions;
using ControlUsuarios.Models;
using ControlUsuarios.Repositories;
using ControlUsuarios.Repositories.Impl;
using ControlUsuarios.Services;
using ControlUsuarios.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();

// Add services to the container.

builder.Services.AddDbContext<userContext>(options =>
{
    var connectionString = configuration.GetConnectionString("HospitalBocaConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
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

