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

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var CumplimientoRequisito = await LCumplimientoRequisito.Listar();
            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);

        }


        public async Task<ActionResult> Lista(int planDesarrolloID, string Mensaje)
        {
            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            var CumplimientoRequisito = await LCumplimientoRequisito.ListarPorPlanDesarrolloID(planDesarrolloID);

            //var RangosFiltrados = await LRango.RangosPorRuta(3);

            return View(CumplimientoRequisito);
        }




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
                return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
            }
        }

        //public async Task<ActionResult> Agregar(int PlanDesarrolloID)
        //{

        //    if (Mensaje != "")
        //    {
        //        ViewBag.Mensaje = Mensaje;
        //    }
        //    CumplimientoRequisitoModel CumplimientoRequisito = new CumplimientoRequisitoModel();
        //    ViewBag.Rango = await LRango.Listar();
        //    ViewBag.Rutas = await LRuta.Listar();
        //    ViewBag.Requisito = await LRequisito.Listar();
        //    ViewBag.Colaborador = await LUsuario.Listar();


        //    return View(CumplimientoRequisito);
        //}


        //[HttpPost]
        //public async Task<ActionResult> Agregar(CumplimientoRequisitoModel Modelo)
        //{

        //    Modelo.FechaRegistro = DateTime.Now;
        //    Modelo.AprobadoPorSupervisor = 24;

        //    var Agregar = await LCumplimientoRequisito.Agregar(Modelo);
        //    if (Agregar.CumplimientoRequisitoID != null)
        //    {
        //        Modelo = new CumplimientoRequisitoModel();
        //        return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Agrega" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "CumplimientoRequisito", new { Mensaje = "Error" });
        //    }

        //}

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
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
            }


        }



        public async Task<ActionResult> Aprobar(int CumplimientoRequisitoID, string Mensaje)
        {

            if (Mensaje != "")
            {
                ViewBag.Mensaje = Mensaje;
            }

            ViewBag.Rango = await LRango.Listar();
            ViewBag.Requisito = await LRequisito.Listar();
            ViewBag.Colaborador = await LUsuario.Listar();
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
            // Obtener el objeto para saber el PlanDesarrolloID antes de eliminarlo.
            var objeto = await LCumplimientoRequisito.Obtener(IdObjeto);
            if (objeto == null)
            {
                // El objeto no fue encontrado; manejar este caso adecuadamente.
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
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
                return RedirectToAction("Index", "PlanDesarrolloProfesional", new { Mensaje = "Error" });
            }
        }


    }
}
