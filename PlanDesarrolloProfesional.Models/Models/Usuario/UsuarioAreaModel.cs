using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{
    public class UsuarioAreaModel
    {
        public UsuarioAreaModel()
        {}
        public UsuarioAreaModel(UsuarioArea Objeto)
        {
            UsuarioID = Objeto.UsuarioID;
            AreaID = Objeto.AreaID;
            UsuarioAreaID = Objeto.UsuarioAreaID;
            Eliminado = Objeto.Eliminado;
        }
        public int UsuarioID { get; set; }

        public int AreaID { get; set; }

        [Key]
        public int UsuarioAreaID { get; set; }

        public bool? Eliminado { get; set; }

        public UsuarioArea ConvertBD()
        {
            return new UsuarioArea
            {

                UsuarioID = UsuarioID,
                AreaID = AreaID,
                UsuarioAreaID = UsuarioAreaID,
                Eliminado = Eliminado
            };
        }
    }
}
