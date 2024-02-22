#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public class RutaModel
{
    public RutaModel()
    {

    }
    public RutaModel(Ruta Objeto)
    {
        RutaID = Objeto.RutaID;
        NombreRuta = Objeto.NombreRuta;
        Descripcion = Objeto.Descripcion;
        AreaID = Objeto.AreaID;
    }
    [Key]
    public int RutaID { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [StringLength(50)]
    public string NombreRuta { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [StringLength(50)]
    public string Descripcion { get; set; }

    public int AreaID { get; set; }

    public Ruta ConvertBD()
    {
        return new Ruta
        {
            RutaID = RutaID,
            NombreRuta = NombreRuta,
            Descripcion = Descripcion,
            AreaID = AreaID
        };
    }


}
