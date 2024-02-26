using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IRango
    {
        Task<RangoModel> Agregar(RangoModel Modelo);
        Task<RangoModel> Obtener(int IdRango);
        //Task<RangoModel> Inactivar(int IdPedido);
        Task<RangoModel> Actualizar(RangoModel modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RangoModel>> Listar();
        Task<bool> Eliminar(int IdRango);
    }
}

