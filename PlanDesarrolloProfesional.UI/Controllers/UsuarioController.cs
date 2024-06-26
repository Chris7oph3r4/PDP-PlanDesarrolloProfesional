﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;
        private JerarquiasLogic LJerarquias;
        private AreaLogic LAreas;

        public UsuarioController()
        {
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic(); 
            LJerarquias = new JerarquiasLogic();
            LAreas = new AreaLogic();

        }

        
        public async Task<ActionResult> Index(string Mensaje)
        {
            

            // Comprobar si el usuario tiene el rol de Administrador
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Usuario = await LUsuario.ListarVM();

            return View(Usuario);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }

        //public async Task<ActionResult> Agregar(string Mensaje)
        //{

        //    if (Mensaje != "")
        //    {
        //        ViewBag.Mensaje = Mensaje;
        //    }
        //    UsuarioAgregarViewModel Usuario = new UsuarioAgregarViewModel();
        //    ViewBag.Roles = await LRoles.Listar();
        //    ViewBag.Jerarquias = await LJerarquias.Listar();
        //    ViewBag.Areas = await LAreas.Listar();
        //    ViewBag.Supervisor = await LUsuario.Listar();
        //    return View(Usuario);

        //}


        public async Task<ActionResult> Agregar(string Mensaje)
        {
         

            // Comprobar si el usuario tiene el rol de Administrador
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (!string.IsNullOrEmpty(Mensaje))
                {
                    ViewBag.Mensaje = Mensaje;
                }

                UsuarioAgregarViewModel usuarioVM = new UsuarioAgregarViewModel();
                ViewBag.Roles = await LRoles.Listar();
                ViewBag.Jerarquias = await LJerarquias.Listar();
                ViewBag.Areas = await LAreas.Listar();
                ViewBag.Supervisor = await LUsuario.Listar();

                return View(usuarioVM);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }
        }


        
        [HttpPost]
        public async Task<ActionResult> Agregar(UsuarioAgregarViewModel Modelo)
        {

            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            Modelo.CodigoDaloo = Guid.NewGuid();
            var Agregar = await LUsuario.AgregarUsuarioAreaJerarquia(Modelo,nameClaim);
            
            if (Agregar.UsuarioID != null)
            {
                Modelo = new UsuarioAgregarViewModel();
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
            }

           

        }

      
        public async Task<ActionResult> Modificar(int UsuarioID, string Mensaje)
        {
            

            // Comprobar si el usuario tiene el rol de Administrador
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {

                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            ViewBag.Roles = await LRoles.Listar();
            ViewBag.Jerarquias = await LJerarquias.Listar();
            ViewBag.Areas = await LAreas.Listar();
            ViewBag.Supervisor = await LUsuario.Listar();
            UsuarioAgregarViewModel Usuario = await LUsuario.ObtenerUA(UsuarioID);

            return View(Usuario);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }

     

        [HttpPost]
        public async Task<ActionResult> Modificar(UsuarioAgregarViewModel Modelo)
        {

            UsuarioAgregarViewModel Usuario = await LUsuario.ObtenerUA(Modelo.UsuarioID);
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            var Modificar = await LUsuario.Actualizar(Modelo,nameClaim);
            if (Modificar.UsuarioID != null)
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {
           

            // Comprobar si el usuario tiene el rol de Administrador
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
                var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

                var Eliminar = await LUsuario.Eliminar(IdObjeto,nameClaim);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
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
