using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models;

    public class CumplimientoRequisitoModel
{
    public CumplimientoRequisitoModel()
    {

    }

    public CumplimientoRequisitoModel(CumplimientoRequisito objeto)
    {
        CumplimientoRequisitoID = objeto.CumplimientoRequisitoID;
        RequisitoID = objeto.RequisitoID;
        ColaboradorID = objeto.ColaboradorID;
        FechaRegistro = objeto.FechaRegistro;
        FechaObtencion = objeto.FechaObtencion;
        URLEvidencia = objeto.URLEvidencia;
        AprobadoPorSupervisor = objeto.AprobadoPorSupervisor;
        PlanDesarrolloID = objeto.PlanDesarrolloID;
        FechaArpobacion = objeto.FechaArpobacion;
    }

    [Key]
    public int CumplimientoRequisitoID { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public int RequisitoID { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public int ColaboradorID { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public DateTime FechaRegistro { get; set; }

    public DateTime FechaObtencion { get; set; }

    [StringLength(256)]
    public string URLEvidencia { get; set; }

    public int AprobadoPorSupervisor { get; set; }

    public int PlanDesarrolloID { get; set; }

    public DateTime FechaArpobacion { get; set; }

    public CumplimientoRequisito ConvertBD()
    {
        return new CumplimientoRequisito
        {
            CumplimientoRequisitoID = CumplimientoRequisitoID,
            RequisitoID = RequisitoID,
            ColaboradorID = ColaboradorID,
            FechaRegistro = FechaRegistro,
            FechaObtencion = FechaObtencion,
            URLEvidencia = URLEvidencia,
            AprobadoPorSupervisor = AprobadoPorSupervisor,
            PlanDesarrolloID = PlanDesarrolloID,
            FechaArpobacion = FechaArpobacion
        };
    }
}

