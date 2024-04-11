using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class RequisitoController : Controller
    {
        private RequisitoLogic LRequisito;
        private RangoLogic LRango;
        private RutaLogic LRuta;

        public RequisitoController()
        {
            LRequisito = new RequisitoLogic();
            LRango = new RangoLogic();
            LRuta = new RutaLogic();
        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Requisito = await LRequisito.Listar();
            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(Requisito);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RequisitoModel Requisito = new RequisitoModel();
            ViewBag.Rutas = await LRuta.Listar();
            ViewBag.Rango = await LRango.Listar();

            return View(Requisito);

        }

        //public async Task<JsonResult> ObtenerRangosPorRuta(int rutaId)
        //{
        //    // Lógica para obtener los rangos asociados a la rutaId
        //    var rangos = await LRango.RangosPorRuta(rutaId);

        //        var settings = new JsonSerializerSettings
        //        {
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        };

        //         var json = JsonConvert.SerializeObject(rangos, settings);



        //    return Json(rangos);
        //}
        public async Task<IActionResult> ObtenerRangosPorRuta(int rutaId)
        {
            // Lógica para obtener los rangos asociados a la rutaId
            var rangos = await LRango.RangosPorRuta(rutaId);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(rangos, settings);

            return Content(json, "application/json");
        }


        [HttpPost]
        public async Task<ActionResult> Agregar(RequisitoModel Modelo)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            //Modelo.RangoID = 1;
            var Agregar = await LRequisito.Agregar(Modelo,nameClaim);
            if (Agregar.RequisitoID != null)
            {
                Modelo = new RequisitoModel();
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int RequisitoID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RequisitoModel Requisito = await LRequisito.Obtener(RequisitoID);
            ViewBag.Rutas = await LRuta.Listar();
            ViewBag.Rango = await LRango.Listar();

            return View(Requisito);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RequisitoModel Modelo)
        {

            RequisitoModel Usuario = await LRequisito.Obtener(Modelo.RequisitoID);
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            var Modificar = await LRequisito.Actualizar(Modelo, nameClaim);
            if (Modificar.RequisitoID != null)
            {
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {

            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
            var Eliminar = await LRequisito.Eliminar(IdObjeto, nameClaim);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Requisito", new { Mensaje = "Error" });
            }


        }

    }
}
