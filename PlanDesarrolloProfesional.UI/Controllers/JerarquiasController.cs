using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class JerarquiasController : Controller
    {
        private JerarquiasLogic LJerarquias;
     
        public JerarquiasController()
        {
            LJerarquias = new JerarquiasLogic();
      
        }
        public async Task<ActionResult> Index(string Mensaje)
        {
          
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }

                var Jerarquias = await LJerarquias.Listar();

                return View(Jerarquias);
        
        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {
        
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }
                JerarquiasModel Usuario = new JerarquiasModel();
               
                return View(Usuario);
        
        }



        [HttpPost]
        public async Task<ActionResult> Agregar(JerarquiasModel Modelo)
        {
               
                var Agregar = await LJerarquias.Agregar(Modelo);
                if (Agregar.JerarquiaID != null)
                {
                Modelo = new JerarquiasModel();
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Agrega" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
                }
         
        }

        public async Task<ActionResult> Modificar(int JerarquiaID, string Mensaje)
        {
        
                if (Mensaje != "")
                {
                    ViewBag.Mensaje = Mensaje;
                }
                JerarquiasModel Jerarquia = await LJerarquias.Obtener(JerarquiaID);
             
                return View(Jerarquia);
         
        }



        [HttpPost]
        public async Task<ActionResult> Modificar(JerarquiasModel Modelo)
        {
          
                JerarquiasModel Usuario = await LJerarquias.Obtener(Modelo.JerarquiaID);
               
               
                var Modificar = await LJerarquias.Actualizar(Modelo);
                if (Modificar.JerarquiaID != null)
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Modifica" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
                }
            

        } 
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {
               
               
                var Eliminar = await LJerarquias.Eliminar(IdObjeto);
                if (Eliminar)
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Eliminado" });
                }
                else
                {
                    return RedirectToAction("Index", "Jerarquias", new { Mensaje = "Error" });
                }
            

        }

    }
}
