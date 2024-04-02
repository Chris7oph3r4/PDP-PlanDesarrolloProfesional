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
    public class LRequisito : IRequisito
    {
        private DARequisito _DARequisito;
        private DARango _DARango;


        public LRequisito(IConfiguration configuration)
        {
            _DARequisito = new DARequisito();
            _DARango = new DARango();   

        }

        public async Task<RequisitoModel> Agregar(List<object> Modelo)
        {
            RequisitoModel Model;
            try
            {
                var respuesta = await _DARequisito.Agregar(JsonConvert.DeserializeObject<RequisitoModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                Model = new RequisitoModel(respuesta);
                return Model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RequisitoModel> Obtener(int IdRequisito)
        {
            try
            {
                RequisitoModel Objeto = new RequisitoModel(await _DARequisito.Obtener(IdRequisito));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RequisitoViewModel>> Listar()
        {
            try
            {
                List<RequisitoViewModel> requisitos = new List<RequisitoViewModel>();
                var ListaObjetoBD = await _DARequisito.Listar();
                IEnumerable<RequisitoModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new RequisitoModel(ObjetoBD)).ToList();

                foreach (RequisitoModel item in ListaRespuestaModel)
                {
                    if (item.Estado.Equals(0)) { 
                        Rango rangomodel = await _DARango.Obtener(item.RangoID);
                        RequisitoViewModel modelo = new RequisitoViewModel()
                        {
                            Estado = item.Estado,
                            NombreRequisito = item.NombreRequisito,
                            RangoID = item.RangoID,
                            RangoNombre = rangomodel.NombreRango,
                            RequisitoID = item.RequisitoID
                        };
                        requisitos.Add(modelo);
                    }
                }

                return requisitos;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<RequisitoViewModel>().AsEnumerable();
            }
        }

        //public async Task<RequisitoModel> Inactivar(int IdRequisito)
        //{
        //    try
        //    {
        //        RequisitoModel Objeto = new RequisitoModel(await _DARequisito.Inactivar(IdRequisito));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<RequisitoModel> Actualizar(List<object> modelo)
        {
            RequisitoModel model;
            try
            {
                var Objeto = await _DARequisito.Actualizar(JsonConvert.DeserializeObject<RequisitoModel>(modelo[0]?.ToString()).ConvertBD(), modelo[1]?.ToString());
                model = new RequisitoModel(Objeto);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    try
        //    {
        //        var Lista = await _DAPRequisito.ListarPorUsuario(IdUsuario);

        //        return Lista;
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<RequisitoViewModel>().AsEnumerable();
        //    }
        //}

        public async Task<bool> Eliminar(int IdRequisito, string nameclaim)
        {
            try
            {
                bool Objeto = await _DARequisito.Eliminar(IdRequisito,nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
