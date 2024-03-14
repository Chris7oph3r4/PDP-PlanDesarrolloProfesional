﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class JerarquiasController : Controller
    {
        private JerarquiasLogic LJerarquias;
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;

        public JerarquiasController()
        {
            LJerarquias = new JerarquiasLogic();
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

                var Jerarquias = await LJerarquias.Listar();

                return View(Jerarquias);
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
                JerarquiasModel Usuario = new JerarquiasModel();
               
                return View(Usuario);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(JerarquiasModel Modelo)
        {
               
                var Agregar = await LJerarquias.Agregar(Modelo);
                if (Agregar.JerarquiaID != null)
                {
                Modelo = new JerarquiasModel();
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Agrega" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
                }
         
        }

        public async Task<ActionResult> Modificar(int JerarquiaID, string Mensaje)
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
                JerarquiasModel Jerarquia = await LJerarquias.Obtener(JerarquiaID);
             
                return View(Jerarquia);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(JerarquiasModel Modelo)
        {
          
                JerarquiasModel Usuario = await LJerarquias.Obtener(Modelo.JerarquiaID);
               
               
                var Modificar = await LJerarquias.Actualizar(Modelo);
                if (Modificar.JerarquiaID != null)
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Modifica" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
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

            // Comprobar si el usuario tiene el rol de Administrador
            if (nombreRol == "Administrador") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {

                var Eliminar = await LJerarquias.Eliminar(IdObjeto);
                if (Eliminar)
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Eliminado" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
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
