using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface ICumplimientoRequisito
    {
        Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel Modelo);
        Task<CumplimientoRequisitoViewModel> Obtener(int IdCumplimientoRequisito);
        //Task<CumplimientoRequisitoModel> Inactivar(int IdPedido);
        Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo);
        //Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<CumplimientoRequisitoViewModel>> Listar();

        Task<IEnumerable<CumplimientoRequisitoViewModel>> ListarPorPlanDesarrolloID(int planDesarrolloID, int colaboradorID, string rolID);
        Task<IEnumerable<CumplimientoRequisitoViewModel>> ObtenerAprobadosPorSupervisor(int supervisorID);

        Task<bool> Eliminar(int IdCumplimientoRequisito);
    }
}
