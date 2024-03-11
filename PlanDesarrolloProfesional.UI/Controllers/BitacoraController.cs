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

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Bitacora = await LBitacora.Listar();

            return View(Bitacora);

        }
    }
}
