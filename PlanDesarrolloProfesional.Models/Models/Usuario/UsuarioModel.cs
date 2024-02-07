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

        public int AreaID { get; set; }

        public int JerarquiaID { get; set; }

        public Guid CodigoDaloo { get; set; }
    }
}
