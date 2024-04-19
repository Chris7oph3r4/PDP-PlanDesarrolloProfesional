using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol;
using PlanDesarrolloProfesional.ConsumeLogic;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Net;
using System.Security.Claims;

namespace PlanDesarrolloProfesional.UI.Controllers
{
    [Authorize]
    public class CumplimientoRequisitoController : Controller
    {
        private CumplimientoRequisitoLogic LCumplimientoRequisito;
        private PlanDesarrolloProfesionalLogic LPlanDesarrollo;
        private RequisitoLogic LRequisito;
        private RangoLogic LRango;
        private UsuarioLogic LUsuario;
        private RutaLogic LRuta;



        public CumplimientoRequisitoController()
        {
            LCumplimientoRequisito = new CumplimientoRequisitoLogic();
            LPlanDesarrollo = new PlanDesarrolloProfesionalLogic();
            LUsuario = new UsuarioLogic();
            LRequisito = new RequisitoLogic();
            LRango = new RangoLogic();
            LRuta = new RutaLogic();
        }
 


        public async Task<ActionResult> Index(string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador")
            {
                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var CumplimientoRequisito = await LCumplimientoRequisito.Listar();
            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);

            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }

        }

        public async Task<ActionResult> Lista(int planDesarrolloID, string Mensaje)
        {
            // Comprobar si el usuario tiene el rol de Administrador
            
                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var CumplimientoRequisito = await LCumplimientoRequisito.ListarPorPlanDesarrolloID(planDesarrolloID);

            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);
            }
           
        // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            
        public async Task<ActionResult> ListarSupervisor(string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Supervisor") { 
                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }
           
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var usuarioIdClaim = claimsIdentity.FindFirst("UsuarioIDDB");
            int supervisorID = int.Parse(usuarioIdClaim.Value);

            var CumplimientoRequisito = await LCumplimientoRequisito.ObtenerAprobadosPorSupervisor(supervisorID);

            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);
        }
              else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
    }

}


//public async Task<ActionResult> ListaSupervisor(string Mensaje)
//{
//    if (!User.Identity.IsAuthenticated)
//    {
//        return RedirectToAction("Login", "Account");
//    }

//    var claimsIdentity = User.Identity as ClaimsIdentity;
//    if (claimsIdentity == null)
//    {
//        return BadRequest("El usuario no tiene una identidad válida."); // Usar BadRequest para 400
//    }

//    var usuarioIdClaim = claimsIdentity.FindFirst("UsuarioIDDB");
//    if (usuarioIdClaim == null)
//    {
//        return NotFound("No se encontró el claim UsuarioIDDB."); // Usar NotFound para 404
//    }

//    // Asegúrate de realizar un manejo adecuado de errores aquí
//    if (!int.TryParse(usuarioIdClaim.Value, out var supervisorID))
//    {
//        return BadRequest("El ID del supervisor no es válido.");
//    }

//    if (!string.IsNullOrEmpty(Mensaje))
//    {
//        ViewBag.Mensaje = Mensaje;
//    }

//    var cumplimientoRequisito = await LCumplimientoRequisito.ObtenerAprobadosPorSupervisor(supervisorID);

//    return View(cumplimientoRequisito);
//}




public async Task<ActionResult> Agregar(int PlanDesarrolloID)
        {
            var planDesarrollo = await LPlanDesarrollo.Obtener(PlanDesarrolloID);
            var colaborador = await LUsuario.Obtener(planDesarrollo.ColaboradorID);

            // Inicialización del modelo con PlanDesarrolloID
            CumplimientoRequisitoModel CumplimientoRequisito = new CumplimientoRequisitoModel
            {
                PlanDesarrolloID = PlanDesarrolloID,
                ColaboradorID = planDesarrollo.ColaboradorID, // Asumiendo que tienes esta propiedad



            };

            int rangoID = planDesarrollo.RangoID;

            // rangoID para filtrar los requisitos
            //var RequisitosFiltrados = await LRequisito.RequisitoPorRango(rangoID, PlanDesarrolloID);
            //ViewBag.RequisitosFiltrados = await LRequisito.RequisitoPorRango(rangoID, PlanDesarrolloID);
            var RequisitosFiltrados = await LRequisito.RequisitoPorRango(rangoID, PlanDesarrolloID);
            ViewBag.RequisitosFiltrados = RequisitosFiltrados;
           
            var nombreRango = await LRango.Obtener(rangoID);
            ViewBag.NombreRango = nombreRango.NombreRango;

            // Carga de datos para los ViewBag, si es necesario
            ViewBag.Rango = await LRango.Listar();
            ViewBag.NombreColaborador = colaborador.Nombre;


            return View(CumplimientoRequisito);
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(CumplimientoRequisitoModel Modelo, int RequisitoSeleccionado)
        {
          
            Modelo.RequisitoID = RequisitoSeleccionado;
            Modelo.FechaRegistro = DateTime.Now;
            Modelo.AprobadoPorSupervisor = 2; // Verifica si esto debe ser dinámico o estático.

            var Agregar = await LCumplimientoRequisito.Agregar(Modelo);
            if (Agregar.CumplimientoRequisitoID != 0) // Asegúrate de que este es el criterio correcto para verificar la operación exitosa.
            {
               
                return RedirectToAction("Lista", "CumplimientoRequisito", new { planDesarrolloID = Modelo.PlanDesarrolloID, Mensaje = "Agrega" });
            }
            else
            {
                if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor")
                {
                    return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
                else
                {
                    return RedirectToAction("ListarPorUsuario", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
            }
        }

    

        public async Task<ActionResult> Modificar(int CumplimientoRequisitoID, string Mensaje)
        {
            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            // Aquí, asumiendo que ya has obtenido tu objeto CumplimientoRequisito desde la base de datos...
            CumplimientoRequisitoViewModel CumplimientoRequisito = await LCumplimientoRequisito.Obtener(CumplimientoRequisitoID);

            // Aquí deberías tener el ID del plan de desarrollo asociado para filtrar los requisitos.
            var planDesarrollo = await LPlanDesarrollo.Obtener(CumplimientoRequisito.PlanDesarrolloID);
            int rangoID = planDesarrollo.RangoID;

            // Obtén los requisitos filtrados basados en el rango.
            var requisitosFiltrados = await LRequisito.RequisitoPorRango(rangoID, planDesarrollo.PlanDesarrolloID);

            // Aquí obtienes el ID del requisito actual del modelo de CumplimientoRequisito.
            var requisitoActualID = CumplimientoRequisito.RequisitoID;

            // Lógica para verificar y añadir el requisito actual a la lista si es necesario.
            if (!requisitosFiltrados.Any(r => r.RequisitoID == requisitoActualID))
            {
                var requisitoActual = await LRequisito.Obtener(requisitoActualID);
                if (requisitoActual != null)
                {
                    requisitosFiltrados.Add(new RequisitoModel
                    {
                        RequisitoID = requisitoActual.RequisitoID,
                        NombreRequisito = requisitoActual.NombreRequisito,
                        // Agrega aquí más propiedades según sea necesario.
                    });
                }
            }

            ViewBag.RequisitosFiltrados = requisitosFiltrados;
            var colaborador = await LUsuario.Obtener(CumplimientoRequisito.ColaboradorID);         
            var requisito = await LRequisito.Obtener(CumplimientoRequisito.RequisitoID);
            var rango = await LRango.Obtener(CumplimientoRequisito.RangoID);
            var ruta = await LRuta.Obtener(CumplimientoRequisito.RutaID);
            ViewBag.NombreColaborador = colaborador.Nombre;
            ViewBag.NombreRequisito = requisito.NombreRequisito;
            ViewBag.NombreRango = rango.NombreRango;
            ViewBag.NombreRuta = ruta.NombreRuta;


            return View(CumplimientoRequisito);

        }



        [HttpPost]
        public async Task<ActionResult> Modificar(CumplimientoRequisitoViewModel Modelo)
        {
            CumplimientoRequisitoViewModel CumplimientoActual = await LCumplimientoRequisito.Obtener(Modelo.CumplimientoRequisitoID);
           
            //CumplimientoRequisitoModel Usuario = await LCumplimientoRequisito.Obtener(Modelo.CumplimientoRequisitoID);
            CumplimientoRequisitoModel Cumplimiento = new CumplimientoRequisitoModel
            {
                CumplimientoRequisitoID = CumplimientoActual.CumplimientoRequisitoID,
                RequisitoID = Modelo.RequisitoSeleccionado,
                ColaboradorID = CumplimientoActual.ColaboradorID,
                FechaRegistro = CumplimientoActual.FechaRegistro,
                FechaObtencion = Modelo.FechaObtencion,
                URLEvidencia = Modelo.URLEvidencia,
                AprobadoPorSupervisor = CumplimientoActual.AprobadoPorSupervisor,
                PlanDesarrolloID = CumplimientoActual.PlanDesarrolloID,
                FechaArpobacion = CumplimientoActual.FechaArpobacion = DateTime.Now
                // Asumiendo que RequisitoSeleccionado viene del formulario
               

        };

           
            var Modificar = await LCumplimientoRequisito.Actualizar(Cumplimiento);
            if (Modificar.CumplimientoRequisitoID != null)
            {
                return RedirectToAction("Lista", "CumplimientoRequisito", new { planDesarrolloID = Cumplimiento.PlanDesarrolloID, Mensaje = "Modifica" });
            }
            else
            {
                if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor")
                {
                    return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
                else
                {
                    return RedirectToAction("ListarPorUsuario", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
            }


        }



        public async Task<ActionResult> Aprobar(int CumplimientoRequisitoID, string Mensaje)
        {
            if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor") // Asegúrate de que la ortografía de "adimn" sea intencional y correcta
            {
                if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

         
            CumplimientoRequisitoViewModel CumplimientoRequisito = await LCumplimientoRequisito.Obtener(CumplimientoRequisitoID);
            var colaborador = await LUsuario.Obtener(CumplimientoRequisito.ColaboradorID);
            var requisito = await LRequisito.Obtener(CumplimientoRequisito.RequisitoID);
            var rango = await LRango.Obtener(CumplimientoRequisito.RangoID);
            var ruta = await LRuta.Obtener(CumplimientoRequisito.RutaID);
            ViewBag.NombreColaborador = colaborador.Nombre;
            ViewBag.NombreRequisito = requisito.NombreRequisito;
            ViewBag.NombreRango = rango.NombreRango;
            ViewBag.NombreRuta = ruta.NombreRuta;

            return View(CumplimientoRequisito);
            }
            else
            {
                // Si el usuario no tiene el rol Administrador, redirigir a una ruta apropiada
                return RedirectToAction("AccesoDenegado", "Home");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Aprobar(CumplimientoRequisitoViewModel Modelo)
        {
            CumplimientoRequisitoViewModel CumplimientoActual = await LCumplimientoRequisito.Obtener(Modelo.CumplimientoRequisitoID);
            //CumplimientoRequisitoModel Usuario = await LCumplimientoRequisito.Obtener(Modelo.CumplimientoRequisitoID);
            CumplimientoRequisitoModel Cumplimiento = new CumplimientoRequisitoModel
            {
                CumplimientoRequisitoID = CumplimientoActual.CumplimientoRequisitoID,
                RequisitoID = CumplimientoActual.RequisitoID,
                ColaboradorID = CumplimientoActual.ColaboradorID,
                FechaRegistro = CumplimientoActual.FechaRegistro,
                FechaObtencion = CumplimientoActual.FechaObtencion,
                URLEvidencia = CumplimientoActual.URLEvidencia,
                AprobadoPorSupervisor = Modelo.AprobadoPorSupervisor,
                PlanDesarrolloID = CumplimientoActual.PlanDesarrolloID,
                FechaArpobacion = Modelo.FechaArpobacion = DateTime.Now
            };

            var Modificar = await LCumplimientoRequisito.Actualizar(Cumplimiento);
            if (Modificar.CumplimientoRequisitoID != null)
            {
                
                string userRole = User?.FindFirst("RolID")?.Value;

                if (userRole == "Administrador")
                {
                    // Si el usuario es Administrador
                    return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Modifica" });
                }
                else if (userRole == "Supervisor")
                {
                    // Si el usuario es Supervisor
                    return RedirectToAction("ListarSupervisor", "CumplimientoRequisito", new { Mensaje = "Modifica" });
                }
               
            }
            else
            {
                
                string userRole = User?.FindFirst("RolID")?.Value;

                if (userRole == "Administrador")
                {
                    // Si el usuario es Administrador
                    return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
                }
                else if (userRole == "Supervisor")
                {
                    // Si el usuario es Supervisor
                    return RedirectToAction("ListarSupervisor", "CumplimientoRequisito", new { Mensaje = "Error" });
                }
               
            }

           
            return RedirectToAction("AccesoDenegado", "Home");
        }


        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdObjeto)
        {
            // Obtener el objeto para saber el PlanDesarrolloID antes de eliminarlo.
            var objeto = await LCumplimientoRequisito.Obtener(IdObjeto);
            if (objeto == null)
            {
                if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor")
                {
                    // El objeto no fue encontrado; manejar este caso adecuadamente.
                    return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }else
                {
                    return RedirectToAction("ListarPorUsuario", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
            }

            var planDesarrolloID = objeto.PlanDesarrolloID; // Asumiendo que tienes esta propiedad.

            var Eliminar = await LCumplimientoRequisito.Eliminar(IdObjeto);
            if (Eliminar)
            {
                // Redirige a la vista 'Lista' del controlador 'CumplimientoRequisito'
                // con el PlanDesarrolloID del objeto que acabas de eliminar.
                return RedirectToAction("Lista", "CumplimientoRequisito", new { planDesarrolloID = planDesarrolloID, Mensaje = "Eliminado" });
            }
            else
            {
                if (User?.FindFirst("RolID")?.Value == "Administrador" || User?.FindFirst("RolID")?.Value == "Supervisor")
                {
                    return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
                else
                {
                    return RedirectToAction("ListarPorUsuario", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
                }
            }
        }


    }
}
