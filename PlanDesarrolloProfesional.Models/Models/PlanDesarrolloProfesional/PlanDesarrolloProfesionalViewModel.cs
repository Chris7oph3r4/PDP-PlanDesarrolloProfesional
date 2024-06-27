using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{
    public class PlanDesarrolloProfesionalViewModel
    {
        public PlanDesarrolloProfesionalViewModel()
        {
                
        }
        [Key]
        public int PlanDesarrolloID { get; set; }

        public int ColaboradorID { get; set; }
        public string NombreColaborador { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        public int Estado { get; set; }

        public int RangoID { get; set; }
        public string NombreRango { get; set; }
      
        public int RutaID { get; set; }
        public string NombreRuta { get; set; }

        public bool Finalizado { get; set; }
    }
}
