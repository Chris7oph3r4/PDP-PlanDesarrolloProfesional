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
        Task<CumplimientoRequisitoModel> Obtener(int IdCumplimientoRequisito);
        //Task<CumplimientoRequisitoModel> Inactivar(int IdPedido);
        Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo);
        //Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<CumplimientoRequisitoModel>> Listar();
        Task<bool> Eliminar(int IdCumplimientoRequisito);
    }
}
