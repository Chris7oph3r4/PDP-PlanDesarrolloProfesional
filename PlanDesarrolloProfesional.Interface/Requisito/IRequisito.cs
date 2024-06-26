﻿using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

    public interface IRequisito
    {
        Task<RequisitoModel> Agregar(List<object> Modelo);
        Task<RequisitoModel> Obtener(int IdRequisito);
        //Task<RequisitoModel> Inactivar(int IdPedido);
        Task<RequisitoModel> Actualizar(List<object> modelo);
        //Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario);
        Task<IEnumerable<RequisitoViewModel>> Listar();

        Task<IEnumerable<RequisitoModel>> RequisitoPorRango(int idRango, int PlanDesarrolloID);
        Task<bool> Eliminar(int IdRequisito, string nameclaim);
    }
}
