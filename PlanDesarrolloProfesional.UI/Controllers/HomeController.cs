using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;

            // Acceder a los claims del usuario
            var userIdClaim = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userNameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
       
            UsuarioViewModel Usuario = new UsuarioViewModel();//Obtener usuario por correo  
            Usuario.Rol = "Gerente";

            var existingRoleClaim = claimsPrincipal?.FindFirst(ClaimTypes.Role);

            // Si no tiene un claim de rol, agregar uno
            if (existingRoleClaim == null)
            {
                // Crear un nuevo claim de rol
                var newRoleClaim = new Claim(ClaimTypes.Role, Usuario.Rol.ToString());

                // Crear un nuevo ClaimsIdentity y agregar el nuevo claim de rol
                var claimsIdentity = new ClaimsIdentity(claimsPrincipal.Identity);
                claimsIdentity.AddClaim(newRoleClaim);

                // Crear un nuevo ClaimsPrincipal con el ClaimsIdentity actualizado
                var newClaimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Actualizar el ClaimsPrincipal en el contexto actual
                HttpContext.User = newClaimsPrincipal;
            }

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