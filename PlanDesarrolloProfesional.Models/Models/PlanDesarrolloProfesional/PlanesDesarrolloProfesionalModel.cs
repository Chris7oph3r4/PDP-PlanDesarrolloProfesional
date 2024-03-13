using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models;

public class PlanesDesarrolloProfesionalModel
{
    public PlanesDesarrolloProfesionalModel()
    {
            
    }
    public PlanesDesarrolloProfesionalModel(PlanesDesarrolloProfesional Object)
    {
        PlanDesarrolloID = Object.PlanDesarrolloID;
        ColaboradorID = Object.ColaboradorID;
        FechaInicio = Object.FechaInicio; 
        Estado = Object.Estado;
        RangoID = Object.RangoID;
        Finalizado = Object.Finalizado;
            
    }
    [Key]
    public int PlanDesarrolloID { get; set; }

    public int ColaboradorID { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaInicio { get; set; }

    public int Estado { get; set; }

    public int RangoID { get; set; }

    public bool Finalizado { get; set; }

    public PlanesDesarrolloProfesional ConvertBD()
    {
        return new PlanesDesarrolloProfesional
        {
            PlanDesarrolloID = PlanDesarrolloID,
            ColaboradorID = ColaboradorID,
            FechaInicio = FechaInicio,
            Estado = Estado,
            RangoID = RangoID,
            Finalizado = Finalizado
    };
    }
}
