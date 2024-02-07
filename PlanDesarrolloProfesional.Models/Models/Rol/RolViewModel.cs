#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public class RolViewModel
{
    public RolViewModel() { }

    [Key]
    public int RolID { get; set; }

    [Required]
    [StringLength(10)]
    public string NombreRol { get; set; }

    [Required]
    [StringLength(10)]
    public string Descripcion { get; set; }


}