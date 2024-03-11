using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IRuta
    {
        Task<RutaModel> Agregar(List<object> Modelo);
        Task<RutaModel> Obtener(int IdRuta);
        //Task<RutaModel> Inactivar(int IdPedido);
        Task<RutaModel> Actualizar(List<object> modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RutaModel>> Listar();
        Task<bool> Eliminar(int IdRuta, string nameclaim);
    }
}

