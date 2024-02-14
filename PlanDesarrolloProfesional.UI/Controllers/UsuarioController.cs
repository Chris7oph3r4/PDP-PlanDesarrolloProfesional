using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioLogic LUsuario;
        private RolLogic LRoles;
        private JerarquiasLogic LJerarquias;
        private AreaLogic LAreas;

        public UsuarioController()
        {
            LUsuario = new UsuarioLogic();
            LRoles = new RolLogic(); 
            LJerarquias = new JerarquiasLogic();
            LAreas = new AreaLogic();

        }
        public async Task<ActionResult> Index(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var Usuario = await LUsuario.ListarVM();

            return View(Usuario);

        }

        public async Task<ActionResult> Agregar(string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            UsuarioAgregarViewModel Usuario = new UsuarioAgregarViewModel();
            ViewBag.Roles = await LRoles.Listar();
            ViewBag.Jerarquias = await LJerarquias.Listar();
            ViewBag.Areas = await LAreas.Listar();
            ViewBag.Supervisor = await LUsuario.Listar();
            return View(Usuario);

        }



        [HttpPost]
        public async Task<ActionResult> Agregar(UsuarioAgregarViewModel Modelo)
        {
            //convertir usuariosagregarviewmodel a usuariomodel
            //    Foreach de area
            Modelo.CodigoDaloo = Guid.NewGuid();
            var Agregar = await LUsuario.AgregarUsuarioAreaJerarquia(Modelo);
            
            if (Agregar.UsuarioID != null)
            {
                Modelo = new UsuarioAgregarViewModel();
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Agrega" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
            }

           

        }

        public async Task<ActionResult> Modificar(int UsuarioID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
            ViewBag.Roles = await LRoles.Listar();
            ViewBag.Jerarquias = await LJerarquias.Listar();
            ViewBag.Areas = await LAreas.Listar();
            UsuarioModel Usuario = await LUsuario.Obtener(UsuarioID);

            return View(Usuario);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(UsuarioModel Modelo)
        {

            UsuarioModel Usuario = await LUsuario.Obtener(Modelo.UsuarioID);


            var Modificar = await LUsuario.Actualizar(Modelo);
            if (Modificar.UsuarioID != null)
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Modifica" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
            }


        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {


            var Eliminar = await LUsuario.Eliminar(IdObjeto);
            if (Eliminar)
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Eliminado" });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", new { Mensaje = "Error" });
            }


        }
    }
}
