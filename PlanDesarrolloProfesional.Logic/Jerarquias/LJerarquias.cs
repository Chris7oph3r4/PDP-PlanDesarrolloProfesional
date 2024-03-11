using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarJerarquiasloProfesional.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LJerarquias : IJerarquias
    {
        private DAJerarquias _DAJerarquias;


        public LJerarquias(IConfiguration configuration)
        {
            _DAJerarquias = new DAJerarquias();

        }

        public async Task<JerarquiasModel> Agregar(List<object> Modelo)
        {
            JerarquiasModel model;
            try
            {
                var respuesta = await _DAJerarquias.Agregar(JsonConvert.DeserializeObject<JerarquiasModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                model = new JerarquiasModel(respuesta);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<JerarquiasModel> Obtener(int IdJerarquias)
        {
            try
            {
                JerarquiasModel Objeto = new JerarquiasModel(await _DAJerarquias.Obtener(IdJerarquias));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<JerarquiasModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAJerarquias.Listar();
                IEnumerable<JerarquiasModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new JerarquiasModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<JerarquiasModel>().AsEnumerable();
            }
        }

        //public async Task<JerarquiasModel> Inactivar(int IdJerarquias)
        //{
        //    try
        //    {
        //        JerarquiasModel Objeto = new JerarquiasModel(await _DAJerarquias.Inactivar(IdJerarquias));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<JerarquiasModel> Actualizar(List<object> modelo)
        {
            JerarquiasModel model;
            try
            {
                var Objeto = await _DAJerarquias.Actualizar(JsonConvert.DeserializeObject<JerarquiasModel>(modelo[0]?.ToString()).ConvertBD(), modelo[1]?.ToString());
                model = new JerarquiasModel(Objeto);
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

        public async Task<bool> Eliminar(int IdJerarquias, string nameclaim)
        {
            try
            {
                bool Objeto = await _DAJerarquias.Eliminar(IdJerarquias, nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
