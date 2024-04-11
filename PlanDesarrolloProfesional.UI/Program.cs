using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.Models.Models.Configuracion;
using System.Text.Json.Serialization;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using PlanDesarrolloProfesional.Models.Models;
using Microsoft.AspNetCore.Authentication;

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
        options.Events.OnTicketReceived += Parameters.OnTicketReceivedFunc;
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
AppSettings.APIEndpoints.Rol_ObtenerNombreDeLRol = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rol_ObtenerNombreDeLRol").Value;


//El consumo de Endpoints de Usuario
AppSettings.APIEndpoints.Usuario_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_Agregar").Value;
AppSettings.APIEndpoints.Usuario_AgregarViewModel = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_AgregarViewModel").Value;
AppSettings.APIEndpoints.Usuario_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_Actualizar").Value;
AppSettings.APIEndpoints.Usuario_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_Obtener").Value;
AppSettings.APIEndpoints.Usuario_ObtenerPorCorreo = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_ObtenerPorCorreo").Value;
AppSettings.APIEndpoints.Usuario_ObtenerUA = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_ObtenerUA").Value;
AppSettings.APIEndpoints.Usuario_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_Listar").Value;
AppSettings.APIEndpoints.Usuario_ListarVM = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_ListarVM").Value;
AppSettings.APIEndpoints.Usuario_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Usuario_Eliminar").Value;

//El consumo de Endpoints de Ruta
AppSettings.APIEndpoints.Ruta_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Agregar").Value;
AppSettings.APIEndpoints.Ruta_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Actualizar").Value;
AppSettings.APIEndpoints.Ruta_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Obtener").Value;
AppSettings.APIEndpoints.Ruta_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Listar").Value;
AppSettings.APIEndpoints.Ruta_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Ruta_Eliminar").Value;

//El consumo de Endpoints de Rango
AppSettings.APIEndpoints.Rango_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Agregar").Value;
AppSettings.APIEndpoints.Rango_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Actualizar").Value;
AppSettings.APIEndpoints.Rango_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Obtener").Value;
AppSettings.APIEndpoints.Rango_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Listar").Value;
AppSettings.APIEndpoints.Rango_RangoPorRutas = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_RangoPorRutas").Value;
AppSettings.APIEndpoints.Rango_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Rango_Eliminar").Value;

//El consumo de Endpoints de Requisito
AppSettings.APIEndpoints.Requisito_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Agregar").Value;
AppSettings.APIEndpoints.Requisito_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Actualizar").Value;
AppSettings.APIEndpoints.Requisito_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Obtener").Value;
AppSettings.APIEndpoints.Requisito_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Listar").Value;
AppSettings.APIEndpoints.Requisito_RequisitoPorRango = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_RequisitoPorRango").Value;
AppSettings.APIEndpoints.Requisito_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Requisito_Eliminar").Value;

//El consumo de Endpoints de Plan de Desarrollo Profesional
AppSettings.APIEndpoints.PlanDesarrolloProfesional_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:PlanDesarrolloProfesional_Agregar").Value;
AppSettings.APIEndpoints.PlanDesarrolloProfesional_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:PlanDesarrolloProfesional_Actualizar").Value;
AppSettings.APIEndpoints.PlanDesarrolloProfesional_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:PlanDesarrolloProfesional_Obtener").Value;
AppSettings.APIEndpoints.PlanDesarrolloProfesional_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:PlanDesarrolloProfesional_Listar").Value;
AppSettings.APIEndpoints.PlanDesarrolloProfesional_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:PlanDesarrolloProfesional_Eliminar").Value;

//El consumo de Endpoints de Bitacora
AppSettings.APIEndpoints.Bitacora_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:Bitacora_Listar").Value;

//EL consumo de Endpoints de Cumplinetos Profesional
AppSettings.APIEndpoints.CumplimientoRequisito_Agregar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_Agregar").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_Actualizar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_Actualizar").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_Obtener = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_Obtener").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_Listar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_Listar").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_Eliminar = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_Eliminar").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_ListarPorPlanDesarrolloID = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_ListarPorPlanDesarrolloID").Value;
AppSettings.APIEndpoints.CumplimientoRequisito_ObtenerAprobadosPorSupervisor = builder.Configuration.GetSection("PlanDesarrolloProfesional.APIEndpoints:CumplimientoRequisito_ObtenerAprobadosPorSupervisor").Value;

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

public static class Parameters
{
    public static Task OnTicketReceivedFunc(TicketReceivedContext context)
    {
        context.ReturnUri = "/Home/Index";
        var client = new HttpClient();
        var correo = context.Principal.FindFirst(ClaimTypes.Name)?.Value;
        var json = client.GetStringAsync($"https://localhost:7071/api/v1/Usuario/ObtenerPorCorreo?correo={correo}").Result;
        var usuario = JsonConvert.DeserializeObject<UsuarioModel>(json);
        var rol = client.GetStringAsync($"https://localhost:7071/api/v1/Rol/ObtenerNombreDeLRol?IdRol={usuario.RolID.ToString()}").Result;

        if (usuario == null)
        {
            context.HandleResponse();
            context.Response.Redirect("/Shared/Error");
            return Task.CompletedTask;
        }
        //else if (usuario.)
        //{
        //    context.Response.Redirect("/Home/DesactivadoLogin");
        //    context.HandleResponse(); // Suppress the exception
        //    return Task.CompletedTask;
        //}
        else
        {
            try
            {
                ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("NameDB", usuario.Nombre.ToString()));
                ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("UsuarioIDDB", usuario.UsuarioID.ToString()));
                ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("RolID", rol));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("IdRol", usuario.IdRol.ToString()));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("IdEmpresa", usuario.IdEmpresa.ToString()));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("Nombre", usuario.Nombre));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("Rol", usuario.Rol));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("Correo", usuario.Correo));
                //((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("UrlFoto", usuario.UrlFoto ?? ""));
                return Task.FromResult(context.Principal);

            }
            catch
            {
                throw;
            }
        }
    }

}
