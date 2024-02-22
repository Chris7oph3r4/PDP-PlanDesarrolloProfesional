using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Models.Models
{
    internal class RutaViewModel
    {
        public RutaViewModel() { }

        [Key]
        public int RutaID { get; set; }

        [Required]
        [StringLength(25)]
        [Unicode(false)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Descripcion { get; set; }

        public int AreaID { get; set; }

    }
}
