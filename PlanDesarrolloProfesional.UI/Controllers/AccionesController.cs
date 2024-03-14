//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//using PlanDesarrolloProfesional.ConsumeLogic;
//using PlanDesarrolloProfesional.Models.Models;
//using PlanDesarrolloProfesional.UI.Models;
//using System.Diagnostics;
//using System.Security.Claims;

//namespace PlanDesarrolloProfesional.UI.Controllers
//{
//    [Authorize]
//    public class AccionesController : Controller
//    {
      
//        private UsuarioLogic LUsuario;
//        private RolLogic LRoles;

//        public AccionesController(UsuarioLogic usuarioLogic, RolLogic rolLogic)
//        {
           
//            LUsuario = new UsuarioLogic();
//            LRoles = new RolLogic();
//        }

//        public async Task<IActionResult> Index()
//        {
//            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
//            if (string.IsNullOrEmpty(emailOrUsernameClaim))
//            {
//                // Posiblemente mostrar una vista de error o redirigir
//                return RedirectToAction("Error", "Home");
//            }

//            var usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
//            if (usuario == null)
//            {
//                // Mostrar una vista de error o redirigir
//                return RedirectToAction("Error", "Home");
//            }

//            var nombreRol = await LRoles.ObtenerNombreDelRol(usuario.RolID);

//            // Verificar si el usuario tiene el rol 'Administrador'
//            if (nombreRol == "Administrador")
//            {
//                // Pasar los datos a la vista usando un modelo o ViewBag/ViewData
//                var viewModel = new UsuarioViewModel
//                {
//                    usuario = usuario,
//                    NombreRol = nombreRol
//                };

//                return View(viewModel); // Asegúrate de que tienes una vista Index.cshtml en Views/Acciones/
//            }
//            else
//            {
//                // Si el usuario no es un administrador, redirigir a otra página
//                return RedirectToAction("Privacy", "Home");
//            }
//        }
//    }

//}