using hgbr_API.Interfaces;
using hgbr_API.Models;
//using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using API_Hospital_Boca.Bussiness;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//  A PARTIR DE AQUI HAGO LAS COSAS NUEVAS


builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API-Hospital Boca", Version = "v1" });
});


builder.Services.AddDbContext<hgbr_API.Models.HgbrContext>(options => {
    var connectionString = configuration.GetConnectionString("HospitalBocaConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
});


builder.Services.AddScoped<ICatalogosServices, CatalogosServices>();
builder.Services.AddScoped<IPacienteServices, PacienteServices>();

builder.Services.AddControllers();


// AQUI TERMINAN MIS LOCURAS
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
