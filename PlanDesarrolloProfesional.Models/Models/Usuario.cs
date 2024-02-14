﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public partial class Usuario
{
    [Key]
    public int UsuarioID { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Descripcion { get; set; }

    public int RolID { get; set; }

    public int JerarquiaID { get; set; }

    public Guid CodigoDaloo { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Correo { get; set; }

    [ForeignKey("JerarquiaID")]
    [InverseProperty("Usuario")]
    public virtual Jerarquias Jerarquia { get; set; }

    [InverseProperty("Colaborador")]
    public virtual ICollection<PlanDesarrolloProfesional> PlanDesarrolloProfesional { get; set; } = new List<PlanDesarrolloProfesional>();

    [ForeignKey("RolID")]
    [InverseProperty("Usuario")]
    public virtual Rol Rol { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<UsuarioArea> UsuarioArea { get; set; } = new List<UsuarioArea>();

    [InverseProperty("Supervisor")]
    public virtual ICollection<UsuarioJerarquias> UsuarioJerarquiasSupervisor { get; set; } = new List<UsuarioJerarquias>();

    [InverseProperty("Usuario")]
    public virtual ICollection<UsuarioJerarquias> UsuarioJerarquiasUsuario { get; set; } = new List<UsuarioJerarquias>();
}