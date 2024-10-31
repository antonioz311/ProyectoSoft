using Microsoft.EntityFrameworkCore; 
using GestionInventario.Repositories;
using GestionInventario.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a la base de datos en MySQL en Aiven
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) // Ajusta la versión de MySQL si es diferente
    ));

// Inyección de dependencias para los repositorios y servicios
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<ProductoRepositorio>();
builder.Services.AddScoped<ProveedorRepositorio>();
builder.Services.AddScoped<MovimientoRepositorio>();

builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<ProductoServicio>();
builder.Services.AddScoped<ProveedorServicio>();
builder.Services.AddScoped<MovimientoServicio>();

// Agregar controladores y configuración de Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// (Opcional) Configuración de autenticación y autorización si es necesariobuilder.Services.AddAuthorization();

var app = builder.Build();

// Configuración para usar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración básica de la API
app.UseHttpsRedirection();
app.UseRouting();

// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();

