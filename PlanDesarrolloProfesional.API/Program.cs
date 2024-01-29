using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models;

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
