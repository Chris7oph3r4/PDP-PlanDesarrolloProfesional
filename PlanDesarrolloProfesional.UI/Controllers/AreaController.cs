using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class AreaController : Controller
    {
        private AreaLogic LArea;

        public AreaController()
        {
            LArea = new AreaLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {

                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }

                var Area = await LArea.Listar();

                return View(Area);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                    if (Mensaje != "")
                    {
                        ViewBag.Mensaje = Mensaje;
                    }
                    AreaModel Usuario = new AreaModel();

                    return View(Usuario);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(AreaModel Modelo)
        {
            Modelo.CodigoDaloo = Guid.NewGuid();
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            var Agregar = await LArea.Agregar(Modelo, nameClaim);
            if (Agregar.AreaID != null)
            {
                Modelo = new AreaModel();
                return RedirectToAction("Index", "Area", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Area", new { Mensaje = "Error" });
            }

        }

        public async Task<ActionResult> Modificar(int AreaID, string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {

                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }
                AreaModel Area = await LArea.Obtener(AreaID);

                return View(Area);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }
        }



        [HttpPost]
        public async Task<ActionResult> Modificar(AreaModel Modelo)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            AreaModel Usuario = await LArea.Obtener(Modelo.AreaID);


            var Modificar = await LArea.Actualizar(Modelo, nameClaim);
            if (Modificar.AreaID != null)
            {
                return RedirectToAction("Index", "Area", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Area", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {
            var claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var nameClaim = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            var Eliminar = await LArea.Eliminar(IdObjeto, nameClaim);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Area", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Area", new { Mensaje = "Error" });
            }


        }

    }
}
