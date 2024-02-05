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
            Task<JerarquiasModel> Agregar(JerarquiasModel Modelo);
            Task<JerarquiasModel> Obtener(int IdPedido);
            //Task<JerarquiasModel> Inactivar(int IdPedido);
            Task<JerarquiasModel> Actualizar(JerarquiasModel modelo);
            //Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario);
            Task<IEnumerable<JerarquiasModel>> Listar();
            Task<bool> Eliminar(int IdPedido);
        }
}

