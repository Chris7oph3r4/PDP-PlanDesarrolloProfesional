using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IArea
    {
        Task<AreaModel> Agregar(List<object> Modelo);
        Task<AreaModel> Obtener(int IdArea);
        //Task<AreaModel> Inactivar(int IdPedido);
        Task<AreaModel> Actualizar(List<object> modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<AreaModel>> Listar();
        Task<bool> Eliminar(int IdArea, string nameclaim);
    }
}

