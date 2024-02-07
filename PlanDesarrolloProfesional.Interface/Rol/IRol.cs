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
        Task<RolModel> Agregar(RolModel Modelo);
        Task<RolModel> Obtener(int IdRol);
        //Task<RolModel> Inactivar(int IdPedido);
        Task<RolModel> Actualizar(RolModel modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RolModel>> Listar();
        Task<bool> Eliminar(int IdRol);
    }
}

