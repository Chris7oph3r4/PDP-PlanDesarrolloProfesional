using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarArealoProfesional.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LArea : IArea
    {
        private DAArea _DAArea;


        public LArea(IConfiguration configuration)
        {
            _DAArea = new DAArea();

        }

        public async Task<AreaModel> Agregar(List<object> Modelo)
        {
            AreaModel model;
            try
            {
                var respuesta = await _DAArea.Agregar(JsonConvert.DeserializeObject<AreaModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                model = new AreaModel(respuesta);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AreaModel> Obtener(int IdArea)
        {
            try
            {
                AreaModel Objeto = new AreaModel(await _DAArea.Obtener(IdArea));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<AreaModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAArea.Listar();
                IEnumerable<AreaModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new AreaModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<AreaModel>().AsEnumerable();
            }
        }

        //public async Task<AreaModel> Inactivar(int IdArea)
        //{
        //    try
        //    {
        //        AreaModel Objeto = new AreaModel(await _DAArea.Inactivar(IdArea));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<AreaModel> Actualizar(List<object> modelo)
        {
            AreaModel model;
            try
            {
                var Objeto = await _DAArea.Actualizar(JsonConvert.DeserializeObject<AreaModel>(modelo[0]?.ToString()).ConvertBD(), modelo[1]?.ToString());
                model = new AreaModel(Objeto);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    try
        //    {
        //        var Lista = await _DAPRol.ListarPorUsuario(IdUsuario);

        //        return Lista;
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<RolViewModel>().AsEnumerable();
        //    }
        //}

        public async Task<bool> Eliminar(int IdArea, string nameclaim)
        {
            try
            {
                bool Objeto = await _DAArea.Eliminar(IdArea, nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
