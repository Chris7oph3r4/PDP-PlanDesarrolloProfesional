using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{
    public class BitacoraModel
    {
        public BitacoraModel()
        {

        }
        public BitacoraModel(Bitacora Objeto)
        {
            BitacoraID = Objeto.BitacoraID;
            Descripcion = Objeto.Descripcion;
            Usuario = Objeto.Usuario;
            Fecha = Objeto.Fecha;
        }

        [Key]
        public int BitacoraID { get; set; }

        [Required]
        [Unicode(false)]
        public string Descripcion { get; set; }

        [Required]
        [Unicode(false)]
        public string Usuario { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        public Bitacora ConvertBD()
        {
            return new Bitacora
            {
                BitacoraID = BitacoraID,
                Descripcion = Descripcion,
                Usuario = Usuario,
                Fecha = Fecha
            };
        }

    }
}
