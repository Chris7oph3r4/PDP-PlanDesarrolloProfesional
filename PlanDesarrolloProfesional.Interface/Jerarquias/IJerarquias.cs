using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IJerarquias
    {
        Task<JerarquiasModel> Agregar(List<object> Modelo);
        Task<JerarquiasModel> Obtener(int IdJerarquias);
        //Task<JerarquiasModel> Inactivar(int IdPedido);
        Task<JerarquiasModel> Actualizar(List<object> modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<JerarquiasModel>> Listar();
        Task<bool> Eliminar(int IdJerarquias, string nameclaim);
    }
}

