﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public string NombreRequisito { get; set; }
        public int RangoID { get; set; }
        public string NombreRango { get; set; }
        public int RutaID { get; set; }
        public string NombreRuta { get; set; }
       
        public int ColaboradorID { get; set; }

        public string NombreColaborador { get; set; }
        [Required(ErrorMessage = "El campo Requisito es obligatorio.")]
        public int RequisitoSeleccionado { get; set; }


        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        public DateTime FechaObtencion { get; set; }
        [Required(ErrorMessage = "El campo Evidencia es obligatorio.")]
        public string URLEvidencia { get; set; }

        public int AprobadoPorSupervisor { get; set; }

        public int PlanDesarrolloID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaArpobacion { get; set; }

    }
}

