using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models
{
    public class CumplimientoRequisitoViewModel
    {
        public CumplimientoRequisitoViewModel() { }

        [Key]
        public int CumplimientoRequisitoID { get; set; }

        public int RequisitoID { get; set; }

        public int ColaboradorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaObtencion { get; set; }

        public string URLEvidencia { get; set; }

        public int AprobadoPorSupervisor { get; set; }

        public int PlanDesarrolloID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaArpobacion { get; set; }

    }
}

