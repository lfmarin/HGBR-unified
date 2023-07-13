using hgbr_API.Interfaces;
//using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using hgbr_API.ImplInterfaces;
using hgbr_API;

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


builder.Services.AddDbContext<hgbr_API.Models.HospitalBocaContext>(options => {
    var connectionString = configuration.GetConnectionString("HospitalBocaConnectionString");
    var version = ServerVersion.Parse("8.0.26-mysql");
    options.UseMySql(connectionString, version);
});


builder.Services.AddScoped<ICatalogosServices, CatalogosServices>();
builder.Services.AddScoped<IPacientesArchServices, PacientesArchServices>();
builder.Services.AddScoped<IAdmisionesServices, AdmisionesServices>();

builder.Services.AddControllers();

builder.Services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
                });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// AQUI TERMINAN MIS LOCURAS
var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
