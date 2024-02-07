#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public class RolModel
{
    public RolModel()
    {

    }
    public RolModel(Rol Objeto)
    {
        RolID = Objeto.RolID;
        NombreRol = Objeto.NombreRol;
        Descripcion = Objeto.Descripcion;
    }
    [Key]
    public int RolID { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [StringLength(50)]
    public string NombreRol { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [StringLength(50)]
    public string Descripcion { get; set; }

    public Rol ConvertBD()
    {
        return new Rol
        {
            RolID = RolID,
            NombreRol = NombreRol,
            Descripcion = Descripcion
        };
    }


}