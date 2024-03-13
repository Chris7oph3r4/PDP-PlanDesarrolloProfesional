using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class PlanDesarrolloProfesionalController : Controller
    {
        private PlanDesarrolloProfesionalLogic LPlanDesarrollo;
        private UsuarioLogic LUsuario;
        private RangoLogic LRango;
        private RutaLogic LRuta;

        public PlanDesarrolloProfesionalController()
        {
            LPlanDesarrollo = new PlanDesarrolloProfesionalLogic();
            LUsuario = new UsuarioLogic();
            LRuta = new RutaLogic();
            LRango = new RangoLogic();


        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Plan = await LPlanDesarrollo.Listar();

            return View(Plan);

        }
        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            PlanesDesarrolloProfesionalModel Plan = new PlanesDesarrolloProfesionalModel();
            ViewBag.Rutas = await LRuta.Listar();
            ViewBag.Colaborador = await LUsuario.Listar();
            ViewBag.Rangos = await LRango.Listar();
            return View(Plan);

        }

        [HttpPost]
        public async Task<ActionResult> Agregar(PlanesDesarrolloProfesionalModel Modelo)
        {
           
            Modelo.FechaInicio = DateTime.Now;
            Modelo.Estado = 0;
            Modelo.Finalizado = false;
            var Agregar = await LPlanDesarrollo.Agregar(Modelo);

            if (Agregar.PlanDesarrolloID != null)
            {
                Modelo = new PlanesDesarrolloProfesionalModel();
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
            }



        }
        public async Task<ActionResult> Modificar(int PlanDesarrolloID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            ViewBag.Rutas = await LRuta.Listar();
            ViewBag.Colaborador = await LUsuario.Listar();
            ViewBag.Rangos = await LRango.Listar();
            PlanDesarrolloProfesionalViewModel PlanDesarrollo = await LPlanDesarrollo.Obtener(PlanDesarrolloID);

            return View(PlanDesarrollo);

        }
        [HttpPost]
        public async Task<ActionResult> Modificar(PlanDesarrolloProfesionalViewModel Modelo)
        {
            PlanesDesarrolloProfesionalModel Plan = new PlanesDesarrolloProfesionalModel
            {
                PlanDesarrolloID = Modelo.PlanDesarrolloID,
                ColaboradorID = Modelo.ColaboradorID,
                FechaInicio = Modelo.FechaInicio,
                Estado = Modelo.Estado,
                RangoID = Modelo.RangoID,
                Finalizado = Modelo.Finalizado
            };

            var Modificar = await LPlanDesarrollo.Actualizar(Plan);
            if (Modificar.PlanDesarrolloID != null)
            {
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
            }


        }

        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {


            var Eliminar = await LPlanDesarrollo.Eliminar(IdObjeto);
            if (Eliminar)
            {
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
            }


        }
    }
}

