using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarrolloProfesional.UI.Models;
using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;
        private PlanDesarrolloProfesionalLogic LPlanDesarrollo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic();
            LPlanDesarrollo = new PlanDesarrolloProfesionalLogic();
        }

        public async Task<IActionResult> Index()
        {

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // PlanesDesarrolloProfesionalModel Plan = new PlanesDesarrolloProfesionalModel();
            //ViewBag.PlanDesarrolloProfesional = await LPlanDesarrollo.ObtenerCantidadPlanesPorUsuario(userId);

            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
            UsuarioModel usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
            ViewBag.CantidadPlanes = await LPlanDesarrollo.ObtenerCantidadPlanesPorUsuario(usuario.UsuarioID);
            ViewBag.ultimoRangoRegistrado = await LPlanDesarrollo.ObtenerUltimoRangoPorColaborador(usuario.UsuarioID);
            ViewBag.PlanesFinalizados = await LPlanDesarrollo.ContarPlanesFinalizadosPorColaborador(usuario.UsuarioID);
            ViewBag.PlanesPorUsuario = await LPlanDesarrollo.ObtenerPlanesPorColaborador(usuario.UsuarioID);


            ViewBag.AreasPorUsuario = await LUsuario.ListarAreasPorUsuario(usuario.UsuarioID);
            ViewBag.UltimaAreaPorUsuario = await LUsuario.ObtenerUltimaAreaPorUsuario(usuario.UsuarioID);

            ViewBag.RutaPorUsuario = await LUsuario.RutaPorUsuario(usuario.UsuarioID);

            ViewBag.ObtenerNombreRutaPorColaboradorId = await LPlanDesarrollo.ObtenerNombreRutaPorColaboradorId(usuario.UsuarioID);

            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        // Acción para realizar el logout
        public IActionResult Logout()
        {
            return SignOut("Cookies", "OpenIdConnect");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}