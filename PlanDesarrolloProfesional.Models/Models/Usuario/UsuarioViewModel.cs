﻿using Microsoft.EntityFrameworkCore;
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
        public UsuarioViewModel()
        {
                
        }

        public int UsuarioID { get; set; }

        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Descripcion { get; set; }
        public string Rol { get; set; } = null;

        public int RolID { get; set; }
        public string AreaString { get; set; } = null;
        public int AreaID { get; set; }
        public string Jerarquia { get; set; }
        public int JerarquiaID { get; set; }

        public Guid CodigoDaloo { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Correo { get; set; }
    }
}
