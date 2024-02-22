using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class RutaController : Controller
    {
        private RutaLogic LRuta;
        private AreaLogic LArea;

        public RutaController()
        {
            LRuta = new RutaLogic();
            LArea = new AreaLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Ruta = await LRuta.Listar();

            return View(Ruta);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RutaModel Usuario = new RutaModel();
            ViewBag.Areas = await LArea.Listar();

            return View(Usuario);

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(RutaModel Modelo)
        {
        
            var Agregar = await LRuta.Agregar(Modelo);
            if (Agregar.RutaID != null)
            {
                Modelo = new RutaModel();
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int RutaID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            RutaModel Jerarquia = await LRuta.Obtener(RutaID);
            ViewBag.Areas = await LArea.Listar();

            return View(Jerarquia);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(RutaModel Modelo)
        {

            RutaModel Usuario = await LRuta.Obtener(Modelo.RutaID);

            var Modificar = await LRuta.Actualizar(Modelo);
            if (Modificar.RutaID != null)
            {
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {


            var Eliminar = await LRuta.Eliminar(IdObjeto);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Ruta", new { Mensaje = "Error" });
            }


        }

    }
}
