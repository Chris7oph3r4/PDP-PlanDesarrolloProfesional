using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Logic;
using PlanDesarrolloProfesional.Models;
using PlanDesarrolloProfesional.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Configuracion de EntityFramework

//Actualizacion de Contexto

builder.Services.AddDbContext<PlanDesarrolloProfesional.Models.Models.PlanDesarrolloProfesionalContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    });

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseSqlServer(StringConexion.ConexionSQL);
#endregion Configuracion de EntityFramework
#region Inyeccion de dependencias
builder.Services.AddScoped<IJerarquias, LJerarquias>();
builder.Services.AddScoped<IArea, LArea>();
builder.Services.AddScoped<IRol, LRol>();
builder.Services.AddScoped<IUsuario, LUsuario>();
builder.Services.AddScoped<IRuta, LRuta>();
#endregion Inyeccion de dependencias

var app = builder.Build();
IWebHostEnvironment env = app.Environment;
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, true)
    .Build();
StringConexion.ConexionSQL = builder.Configuration.GetConnectionString("SqlConnection"); //cuando se actualiza el contexto, hay que revisar la cadena de conexión del RECOPEContext, ubicado en capa Models


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
