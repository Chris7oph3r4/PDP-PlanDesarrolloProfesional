using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{
    public class UsuarioViewModel
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

        public string Rol { get; set; }

        public string Area { get; set; }

        public string Jerarquia { get; set; }

        public Guid CodigoDaloo { get; set; }
    }
}
