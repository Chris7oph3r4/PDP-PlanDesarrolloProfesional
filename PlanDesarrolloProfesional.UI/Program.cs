using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.Models.Models.Configuracion;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); 
    

#region Autenticacion
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddOpenIdConnect(options =>
    {
        options.Authority = "https://login.microsoftonline.com/6b4bdb6e-4b58-4a85-8791-10ad1dcb170b";
        options.ClientId = "a95eaa0b-c624-4c6f-98e4-2f49bd4b91e7";
        options.ClientSecret = "Tu-Client-Secret";
        options.CallbackPath = "/signin-oidc";
        options.UseTokenLifetime = true;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Puedes ajustar esto según tus necesidades
        };
    });
#endregion Autenticacion

#region AppSettings
#region ConfiguracionAPI

//Usuario de consumo de Endpoints de jerarquias
AppSettings.APIEndpoints.Jerarquias_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Jerarquias_Agregar").Value;
AppSettings.APIEndpoints.Jerarquias_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Jerarquias_Actualizar").Value;
AppSettings.APIEndpoints.Jerarquias_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Jerarquias_Obtener").Value;
AppSettings.APIEndpoints.Jerarquias_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Jerarquias_Listar").Value;
AppSettings.APIEndpoints.Jerarquias_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Jerarquias_Eliminar").Value;

//El consumo de Endpoints de Area
AppSettings.APIEndpoints.Area_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Area_Agregar").Value;
AppSettings.APIEndpoints.Area_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Area_Actualizar").Value;
AppSettings.APIEndpoints.Area_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Area_Obtener").Value;
AppSettings.APIEndpoints.Area_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Area_Listar").Value;
AppSettings.APIEndpoints.Area_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Area_Eliminar").Value;

//El consumo de Endpoints de Rol
AppSettings.APIEndpoints.Rol_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_Agregar").Value;
AppSettings.APIEndpoints.Rol_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_Actualizar").Value;
AppSettings.APIEndpoints.Rol_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_Obtener").Value;
AppSettings.APIEndpoints.Rol_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_Listar").Value;
AppSettings.APIEndpoints.Rol_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_Eliminar").Value;

//El consumo de Endpoints de Ruta
AppSettings.APIEndpoints.Ruta_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Agregar").Value;
AppSettings.APIEndpoints.Ruta_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Actualizar").Value;
AppSettings.APIEndpoints.Ruta_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Obtener").Value;
AppSettings.APIEndpoints.Ruta_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Listar").Value;
AppSettings.APIEndpoints.Ruta_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Eliminar").Value;

//El consumo de Endpoints de Ruta
AppSettings.APIEndpoints.Rango_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Agregar").Value;
AppSettings.APIEndpoints.Rango_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Actualizar").Value;
AppSettings.APIEndpoints.Rango_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Obtener").Value;
AppSettings.APIEndpoints.Rango_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Listar").Value;
AppSettings.APIEndpoints.Rango_RangoPorRutas = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_RangoPorRutas").Value;
AppSettings.APIEndpoints.Rango_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Eliminar").Value;

//El consumo de Endpoints de Ruta
AppSettings.APIEndpoints.Requisito_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Agregar").Value;
AppSettings.APIEndpoints.Requisito_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Actualizar").Value;
AppSettings.APIEndpoints.Requisito_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Obtener").Value;
AppSettings.APIEndpoints.Requisito_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Listar").Value;
AppSettings.APIEndpoints.Requisito_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Eliminar").Value;


#endregion ConfiguracionAPI

#endregion AppSettings
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
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, true)
    .Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
