using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IRol
    {
        Task<RolModel> Agregar(List<object> Modelo);
        Task<RolModel> Obtener(int IdRol);
        //Task<RolModel> Inactivar(int IdPedido);
        Task<RolModel> Actualizar(List<object> modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RolModel>> Listar();
        Task<bool> Eliminar(int IdRol, string nameclaim);
   

        Task<string> ObtenerNombreDelRol(int IdRol);
    }
}

