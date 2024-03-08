using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class RequisitoController : Controller
    {
        private RequisitoLogic LRequisito;
        private RangoLogic LRango;

        public RequisitoController()
        {
            LRequisito = new RequisitoLogic();
            LRango = new RangoLogic();
        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Requisito = await LRequisito.Listar();

            return View(Requisito);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RequisitoModel Requisito = new RequisitoModel();
            ViewBag.Rango = await LRango.Listar();

            return View(Requisito);

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(RequisitoModel Modelo)
        {
       
            Modelo.RangoID = 1;
            var Agregar = await LRequisito.Agregar(Modelo);
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

            return View(Requisito);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RequisitoModel Modelo)
        {

            RequisitoModel Usuario = await LRequisito.Obtener(Modelo.RequisitoID);


            var Modificar = await LRequisito.Actualizar(Modelo);
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


            var Eliminar = await LRequisito.Eliminar(IdObjeto);
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
