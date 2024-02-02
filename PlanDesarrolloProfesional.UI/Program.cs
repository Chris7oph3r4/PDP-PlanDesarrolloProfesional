using Microsoft.AspNetCore.Mvc.Filters;
using PlanDesarrolloProfesional.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

IWebHostEnvironment env = app.Environment;
var env1 = env.WebRootPath;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

#region Appsettings

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, true)
    .Build();
StringConexion.ConexionSQL = builder.Configuration.GetConnectionString("SqlConnection"); //cuando se actualiza el contexto, hay que revisar la cadena de conexion del PlanDesarrolloProfesionalContext, ubicado en capa Models

#endregion Appsettings




app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
