using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{
    public interface ICumplimientoRequisito
    {
        Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel modelo);
        Task<CumplimientoRequisitoModel> Obtener(int idCumplimientoRequisito);
        Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo);
        Task<IEnumerable<CumplimientoRequisitoModel>> Listar();
        Task<bool> Eliminar(int idCumplimientoRequisito);
    }
}
