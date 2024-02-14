using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{

    public class UsuarioModel
    {
        public UsuarioModel()
        {
                
        }
        public UsuarioModel(Usuario Objeto)
        {
            UsuarioID = Objeto.UsuarioID;
            Nombre = Objeto.Nombre;
            Descripcion = Objeto.Descripcion;
            RolID = Objeto.RolID;
        
            JerarquiaID = Objeto.JerarquiaID;
            CodigoDaloo = Objeto.CodigoDaloo;
            Correo =Objeto.Correo;
        }
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

        public Usuario ConvertBD()
        {
            return new Usuario
            {
                UsuarioID = UsuarioID,
                Nombre = Nombre,
                Descripcion = Descripcion,
                RolID = RolID,
                JerarquiaID = JerarquiaID,
                CodigoDaloo = CodigoDaloo,
                Correo = Correo,
        };
        }
    }
}
