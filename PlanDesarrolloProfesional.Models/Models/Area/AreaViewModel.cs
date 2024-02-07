﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public class AreaViewModel
{
    public AreaViewModel() { }

    [Key]
    public int AreaID { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Descripcion { get; set; }

    public Guid CodigoDaloo { get; set; }

}