using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IRequisito
    {
        Task<RequisitoModel> Agregar(RequisitoModel Modelo);
        Task<RequisitoModel> Obtener(int IdRequisito);
        //Task<RequisitoModel> Inactivar(int IdPedido);
        Task<RequisitoModel> Actualizar(RequisitoModel modelo);
        //Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RequisitoModel>> Listar();

        Task<IEnumerable<RequisitoModel>> RequisitoPorRango(int idRango);
        Task<bool> Eliminar(int IdRequisito);
    }
}
