using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarrolloProfesional.UI.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic();
        }

        public IActionResult Index()
        {
           

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