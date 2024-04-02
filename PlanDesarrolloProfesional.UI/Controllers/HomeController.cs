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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic();
        }

        public IActionResult Index()
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;

            // Acceder a los claims del usuario
            var userIdClaim = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userNameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;


            Task<UsuarioModel> usuarioTask = LUsuario.ObtenerPorCorreo(userNameClaim);//Obtener usuario por correo 
            var usuario = usuarioTask.Result;

            var existingRoleClaim = claimsPrincipal?.FindFirst(ClaimTypes.Role);
            var existingNombreClaim = claimsPrincipal?.FindFirst("NameDB");

            // Si no tiene un claim de rol, agregar uno
            //if (existingRoleClaim == null)
            //{
            //    // Crear un nuevo claim de rol
            //    var newRoleClaim = new Claim(ClaimTypes.Role, usuario.RolID.ToString());
            //    //var newRoleClaim = new Claim(ClaimTypes.Role, usuario.Rol.ToString());

            //    // Crear un nuevo ClaimsIdentity y agregar el nuevo claim de rol
            //    var claimsIdentity = new ClaimsIdentity(claimsPrincipal.Identity);
            //    claimsIdentity.AddClaim(newRoleClaim);

            //    // Crear un nuevo ClaimsPrincipal con el ClaimsIdentity actualizado
            //    var newClaimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            //    // Actualizar el ClaimsPrincipal en el contexto actual
            //    HttpContext.User = newClaimsPrincipal;
            //}
            if (existingNombreClaim == null)
            {
                // Crear un nuevo claim personalizado
                var newNombreClaim = new Claim("NameDB", usuario.Nombre); // Cambiar a tu claim personalizado

                // Crear un nuevo ClaimsIdentity y agregar el nuevo claim personalizado
                var claimsIdentity = new ClaimsIdentity(claimsPrincipal.Identity);
                
                claimsIdentity.AddClaim(newNombreClaim);


                if (existingRoleClaim == null)
                {
                    // Crear un nuevo claim de rol
                    var newRoleClaim = new Claim(ClaimTypes.Role, usuario.RolID.ToString());
                    claimsIdentity.AddClaim(newRoleClaim);
                }              

                // Crear un nuevo ClaimsPrincipal con el ClaimsIdentity actualizado
                var newClaimsPrincipal = new ClaimsPrincipal(claimsPrincipal);

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