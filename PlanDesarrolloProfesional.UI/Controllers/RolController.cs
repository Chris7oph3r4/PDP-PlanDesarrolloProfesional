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

        public RolController()
        {
            LRol = new RolLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Rol = await LRol.Listar();

            return View(Rol);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RolModel Usuario = new RolModel();

            return View(Usuario);

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(RolModel Modelo)
        {

            var Agregar = await LRol.Agregar(Modelo);
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

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RolModel Rol = await LRol.Obtener(RolID);

            return View(Rol);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RolModel Modelo)
        {

            RolModel Usuario = await LRol.Obtener(Modelo.RolID);


            var Modificar = await LRol.Actualizar(Modelo);
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


            var Eliminar = await LRol.Eliminar(IdObjeto);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Rol", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Rol", new { Mensaje = "Error" });
            }


        }

    }
}
