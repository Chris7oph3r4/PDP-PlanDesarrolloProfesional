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
    public class CumplimientoRequisitoController : Controller
    {
        private CumplimientoRequisitoLogic LCumplimientoRequisito;
        private RequisitoLogic LRequisito;
        private RangoLogic LRango;
        private RutaLogic LRuta;

        public CumplimientoRequisitoController()
        {
            LCumplimientoRequisito = new CumplimientoRequisitoLogic();
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

            var CumplimientoRequisito = await LCumplimientoRequisito.Listar();
            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            CumplimientoRequisitoModel CumplimientoRequisito = new CumplimientoRequisitoModel();
            //ViewBag.Ruta = await LRuta.Listar();
            //ViewBag.Rango = await LRango.Listar();
            //ViewBag.Requisito = await LRequisito.Listar();


            return View(CumplimientoRequisito);
        }


        [HttpPost]
        public async Task<ActionResult> Agregar(CumplimientoRequisitoModel Modelo)
        {

            Modelo.FechaRegistro = DateTime.Now;
            Modelo.AprobadoPorSupervisor = 24;
            Modelo.FechaArpobacion = DateTime.Now;
            var Agregar = await LCumplimientoRequisito.Agregar(Modelo);
            if (Agregar.CumplimientoRequisitoID != null)
            {
                Modelo = new CumplimientoRequisitoModel();
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int CumplimientoRequisitoID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            CumplimientoRequisitoModel CumplimientoRequisito = await LCumplimientoRequisito.Obtener(CumplimientoRequisitoID);
            //ViewBag.Ruta = await LRuta.Listar();
            //ViewBag.Rango = await LRango.Listar();
            //ViewBag.Requisito = await LRequisito.Listar();

            return View(CumplimientoRequisito);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(CumplimientoRequisitoModel Modelo)
        {

            CumplimientoRequisitoModel Usuario = await LCumplimientoRequisito.Obtener(Modelo.CumplimientoRequisitoID);

            Modelo.AprobadoPorSupervisor = 24;
            var Modificar = await LCumplimientoRequisito.Actualizar(Modelo);
            if (Modificar.CumplimientoRequisitoID != null)
            {
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {


            var Eliminar = await LCumplimientoRequisito.Eliminar(IdObjeto);
            if (Eliminar)
            {
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
            }


        }

        public async Task<IActionResult> ObtenerRequisitoPorRango(int rangoId)
        {
            // Lógica para obtener los rangos asociados a la rutaId
            var requisito = await LRequisito.RequisitoPorRango(rangoId);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(requisito, settings);

            return Content(json, "application/json");
        }

    }
}
