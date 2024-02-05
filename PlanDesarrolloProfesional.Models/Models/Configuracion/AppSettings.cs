using System;
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
        }
    }
}
