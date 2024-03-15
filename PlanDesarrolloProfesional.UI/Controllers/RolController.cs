using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class RolController : Controller
    {
        private RolLogic LRol;
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;

        public RolController()
        {
            LRol = new RolLogic();
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {
            // Obtener el claim de email o username del usuario autenticado
            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
            // Obtener el objeto usuario basado en el email o username
            var usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
            // Ahora que tienes el objeto usuario, puedes obtener el RolID
            string nombreRol = await LRoles.ObtenerNombreDelRol(usuario.RolID);

            // Comprobar si el usuario tiene el rol de Administrador
            if (nombreRol == "Administrador") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }

                var Rol = await LRol.Listar();

                return View(Rol);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }
        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {
            // Obtener el claim de email o username del usuario autenticado
            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
            // Obtener el objeto usuario basado en el email o username
            var usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
            // Ahora que tienes el objeto usuario, puedes obtener el RolID
            string nombreRol = await LRoles.ObtenerNombreDelRol(usuario.RolID);

            // Comprobar si el usuario tiene el rol de Administrador
            if (nombreRol == "Administrador") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }
                RolModel Usuario = new RolModel();

                return View(Usuario);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(RolModel Modelo)
        {

            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            var Agregar = await LRol.Agregar(Modelo, nameClaim);
            if (Agregar.RolID != null)
            {
                Modelo = new RolModel();
                return RedirectToAction("Index", "Rol", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Rol", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int RolID, string Mensaje)
        {
            // Obtener el claim de email o username del usuario autenticado
            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
            // Obtener el objeto usuario basado en el email o username
            var usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
            // Ahora que tienes el objeto usuario, puedes obtener el RolID
            string nombreRol = await LRoles.ObtenerNombreDelRol(usuario.RolID);

            // Comprobar si el usuario tiene el rol de Administrador
            if (nombreRol == "Administrador") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }
                RolModel Rol = await LRol.Obtener(RolID);

                return View(Rol);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RolModel Modelo)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            RolModel Usuario = await LRol.Obtener(Modelo.RolID);


            var Modificar = await LRol.Actualizar(Modelo, nameClaim);
            if (Modificar.RolID != null)
            {
                return RedirectToAction("Index", "Rol", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Rol", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {
            // Obtener el claim de email o username del usuario autenticado
            var emailOrUsernameClaim = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindFirst(ClaimTypes.Name)?.Value;
            // Obtener el objeto usuario basado en el email o username
            var usuario = await LUsuario.ObtenerPorCorreo(emailOrUsernameClaim);
            // Ahora que tienes el objeto usuario, puedes obtener el RolID
            string nombreRol = await LRoles.ObtenerNombreDelRol(usuario.RolID);

            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            // Comprobar si el usuario tiene el rol de Administrador
            if (nombreRol == "Administrador") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {

                var Eliminar = await LRol.Eliminar(IdObjeto, nameClaim);
                if (Eliminar)
                {
                    return RedirectToAction("Index", "Rol", new { Mensaje = "Eliminado" });
                }
                else
                {
                    return RedirectToAction("Index", "Rol", new { Mensaje = "Error" });
                }
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }
        }

    }
}

