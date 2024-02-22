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
        Task<RutaModel> Agregar(RutaModel Modelo);
        Task<RutaModel> Obtener(int IdRuta);
        //Task<RutaModel> Inactivar(int IdPedido);
        Task<RutaModel> Actualizar(RutaModel modelo);
        //Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RutaModel>> Listar();
        Task<bool> Eliminar(int IdRuta);
    }
}

