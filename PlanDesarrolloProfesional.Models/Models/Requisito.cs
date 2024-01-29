﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public partial class Requisito
{
    [Key]
    public int RequisitoID { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string NombreRequisito { get; set; }

    public int Estado { get; set; }

    public int RangoID { get; set; }

    [InverseProperty("Requisito")]
    public virtual ICollection<CumplimientoRequisito> CumplimientoRequisito { get; set; } = new List<CumplimientoRequisito>();

    [ForeignKey("RangoID")]
    [InverseProperty("Requisito")]
    public virtual RutaRango Rango { get; set; }
}