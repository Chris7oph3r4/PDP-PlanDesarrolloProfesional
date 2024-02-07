using PlanDesarrolloProfesional.Models.Models.Configuracion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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


#endregion ConfiguracionAPI

#endregion AppSettings
var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
