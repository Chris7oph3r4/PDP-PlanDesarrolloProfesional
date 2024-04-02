using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LRango : IRango
    {
        private DARango _DARango;


        public LRango(IConfiguration configuration)
        {
            _DARango = new DARango();

        }

        public async Task<RangoModel> Agregar(List<object> Modelo)
        {
            RangoModel Model;
            try
            {
                var respuesta = await _DARango.Agregar(JsonConvert.DeserializeObject<RangoModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                Model = new RangoModel(respuesta);
                return Model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RangoModel> Obtener(int IdRango)
        {
            try
            {
                RangoModel Objeto = new RangoModel(await _DARango.Obtener(IdRango));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RangoModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DARango.Listar();
                IEnumerable<RangoModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new RangoModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<RangoModel>().AsEnumerable();
            }
        }

        //public async Task<RangoModel> Inactivar(int IdRango)
        //{
        //    try
        //    {
        //        RangoModel Objeto = new RangoModel(await _DARango.Inactivar(IdRango));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<RangoModel> Actualizar(List<object> Modelo)
        {
            RangoModel model;
            try
            {
                var Objeto = await _DARango.Actualizar(JsonConvert.DeserializeObject<RangoModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                model = new RangoModel(Objeto);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    try
        //    {
        //        var Lista = await _DAPJerarquias.ListarPorUsuario(IdUsuario);

        //        return Lista;
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<JerarquiasViewModel>().AsEnumerable();
        //    }
        //}

        public async Task<bool> Eliminar(int IdRango, string nameclaim)
        {
            try
            {
                bool Objeto = await _DARango.Eliminar(IdRango, nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Task<IEnumerable<RangoModel>> RangosPorRuta(int IdRuta)
        {
            try
            {
                var ListaObjetoBD =  _DARango.RangosPorRuta(IdRuta);
                

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return (Task<IEnumerable<RangoModel>>)Enumerable.Empty<RangoModel>();
            }
        }

    }
}
