using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{
    public interface IBitacora
    {
        Task<IEnumerable<BitacoraModel>> Listar();
    }
}
