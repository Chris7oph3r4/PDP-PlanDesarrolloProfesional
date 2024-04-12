using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{
    public interface IPlanDesarrolloProfesional
    {
        Task<PlanesDesarrolloProfesionalModel> Agregar(List<object> Modelo);
        Task<PlanDesarrolloProfesionalViewModel> Obtener(int IdPlan);
        Task<PlanesDesarrolloProfesionalModel> Actualizar(List<object> modelo);
        Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> Listar();
        Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> ListarPorUsuario(int usuarioID);
        Task<bool> Eliminar(int IdPlan, string nameclaim);
    }
}
