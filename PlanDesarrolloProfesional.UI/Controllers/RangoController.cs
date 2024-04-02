using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class RangoController : Controller
    {
        private RangoLogic LRango;
        private RutaLogic LRuta;
       

        public RangoController()
        {
            LRango = new RangoLogic();
            LRuta = new RutaLogic();
          ;

        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Rango = await LRango.Listar();

            return View(Rango);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RangoModel Usuario = new RangoModel();
            ViewBag.Ruta = await LRuta.Listar();

            return View(Usuario);

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(RangoModel Modelo)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            var Agregar = await LRango.Agregar(Modelo,nameClaim);
            if (Agregar.RangoID != null)
            {
                Modelo = new RangoModel();
                return RedirectToAction("Index", "Rango", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Rango", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int RangoID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RangoModel Rango = await LRango.Obtener(RangoID);
            ViewBag.Ruta = await LRuta.Listar();

            return View(Rango);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RangoModel Modelo)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            RangoModel Usuario = await LRango.Obtener(Modelo.RangoID);

            var Modificar = await LRango.Actualizar(Modelo,nameClaim);
            if (Modificar.RangoID != null)
            {
                return RedirectToAction("Index", "Rango", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Rango", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {

            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            var Eliminar = await LRango.Eliminar(IdObjeto,nameClaim);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Rango", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Rango", new { Mensaje = "Error" });
            }


        }

    }
}
