using Microsoft.Extensions.Configuration;
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


        public LRequisito(IConfiguration configuration)
        {
            _DARequisito = new DARequisito();

        }

        public async Task<RequisitoModel> Agregar(RequisitoModel Modelo)
        {
            try
            {
                var respuesta = await _DARequisito.Agregar(Modelo.ConvertBD());
                Modelo = new RequisitoModel(respuesta);
                return Modelo;
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
        public async Task<IEnumerable<RequisitoModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DARequisito.Listar();
                IEnumerable<RequisitoModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new RequisitoModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<RequisitoModel>().AsEnumerable();
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

        public async Task<RequisitoModel> Actualizar(RequisitoModel modelo)
        {
            try
            {
                var Objeto = await _DARequisito.Actualizar(modelo.ConvertBD());
                modelo = new RequisitoModel(Objeto);
                return modelo;
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

        public async Task<bool> Eliminar(int IdRequisito)
        {
            try
            {
                bool Objeto = await _DARequisito.Eliminar(IdRequisito);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Task<IEnumerable<RequisitoModel>> RequisitoPorRango(int IdRango)
        {
            try
            {
                var ListaObjetoBD = _DARequisito.RequisitoPorRango(IdRango);


                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return (Task<IEnumerable<RequisitoModel>>)Enumerable.Empty<RequisitoModel>();
            }
        }
    }
}
