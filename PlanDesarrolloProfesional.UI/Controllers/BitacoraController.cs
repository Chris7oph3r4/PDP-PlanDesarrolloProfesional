using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class BitacoraController : Controller
    {
        private BitacoraLogic LBitacora;


        public BitacoraController()
        {
            LBitacora = new BitacoraLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }

                var Bitacora = await LBitacora.Listar();

                return View(Bitacora);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }
    }
}
