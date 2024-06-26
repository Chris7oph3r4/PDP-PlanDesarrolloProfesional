﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models.Configuracion
{
    public class AppSettings
    {
        public class APIEndpoints
        {
            public static string Jerarquias_Agregar { get; set; }
            public static string Jerarquias_Obtener { get; set; }
            public static string Jerarquias_Actualizar { get; set; }
            public static string Jerarquias_Eliminar { get; set; }
            public static string Jerarquias_Listar { get; set; }

            public static string Area_Agregar { get; set; }
            public static string Area_Obtener { get; set; }
            public static string Area_Actualizar { get; set; }
            public static string Area_Eliminar { get; set; }
            public static string Area_Listar { get; set; }

            public static string Rol_Agregar { get; set; }
            public static string Rol_Obtener { get; set; }
            public static string Rol_Actualizar { get; set; }
            public static string Rol_Eliminar { get; set; }
            public static string Rol_Listar { get; set; }
            public static string Rol_ObtenerNombreDeLRol { get; set; }

            public static string Usuario_Agregar { get; set; }
            public static string Usuario_Obtener { get; set; }
            public static string Usuario_ObtenerUA { get; set; }
            public static string Usuario_ObtenerPorCorreo { get; set; }
            public static string Usuario_Actualizar { get; set; }
            public static string Usuario_Eliminar { get; set; }
            public static string Usuario_Listar { get; set; }
            public static string Usuario_ListarVM { get; set; }
            public static string Usuario_ListarPorSupervisor { get; set; }
            public static string Usuario_AgregarViewModel { get; set; }
            public static string Usuario_ObtenerUltimaAreaPorUsuario { get; set; }
            public static string Usuario_ListarAreasPorUsuario { get; set; }
            public static string Usuario_RutaPorUsuario { get; set; }




            public static string Ruta_Agregar { get; set; }
            public static string Ruta_Obtener { get; set; }
            public static string Ruta_Actualizar { get; set; }
            public static string Ruta_Eliminar { get; set; }
            public static string Ruta_Listar { get; set; }

            public static string Rango_Agregar { get; set; }
            public static string Rango_Obtener { get; set; }
            public static string Rango_Actualizar { get; set; }
            public static string Rango_Eliminar { get; set; }
            public static string Rango_Listar { get; set; }
            public static string Rango_RangoPorRutas { get; set; }

            public static string Requisito_Agregar { get; set; }
            public static string Requisito_Obtener { get; set; }
            public static string Requisito_Actualizar { get; set; }
            public static string Requisito_Eliminar { get; set; }
            public static string Requisito_Listar { get; set; }
            public static string Requisito_RequisitoPorRango { get; set; }

            public static string PlanDesarrolloProfesional_Agregar { get; set; }
            public static string PlanDesarrolloProfesional_Obtener { get; set; }
            public static string PlanDesarrolloProfesional_Actualizar { get; set; }
            public static string PlanDesarrolloProfesional_Eliminar { get; set; }
            public static string PlanDesarrolloProfesional_Listar { get; set; }
            public static string PlanDesarrolloProfesional_ListarPorUsuario { get; set; }
            public static string PlanDesarrolloProfesional_ObtenerCantidadPlanesPorUsuario { get; set; }
            public static string PlanDesarrolloProfesional_ObtenerUltimoRangoPorColaborador { get; set; }

            public static string PlanDesarrolloProfesional_ContarPlanesFinalizadosPorColaborador { get; set; }
            public static string PlanDesarrolloProfesional_ObtenerPlanesPorColaborador { get; set; }
            public static string PlanDesarrolloProfesional_ObtenerNombreRutaPorColaboradorId { get; set; }



            public static string Bitacora_Listar { get; set; }

            public static string CumplimientoRequisito_Agregar { get; set; }
            public static string CumplimientoRequisito_Obtener { get; set; }
            public static string CumplimientoRequisito_Actualizar { get; set; }
            public static string CumplimientoRequisito_Listar { get; set; }
            public static string CumplimientoRequisito_Eliminar { get; set; }
            public static string CumplimientoRequisito_ListarPorPlanDesarrolloID { get; set; }
            public static string Rango_ObtenerRutaPorRangoID { get; set; }
            public static string CumplimientoRequisito_ObtenerAprobadosPorSupervisor { get; set; }
            
        }
    }
}
