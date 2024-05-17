using MiApi.Business;
using MiApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IProductos, Productobusiness>(); //Inyeccion de dependencia
builder.Services.AddTransient<IPersona, PersonaBusiness>(); //Inyeccion de dependencia
builder.Services.AddTransient<IHome, HomeBusiness>(); //Inyeccion de dependencia
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppConfiguration.Connection = builder.Configuration.GetConnectionString("Connection");

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
