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
    public class LCumplimientoRequisito : ICumplimientoRequisito
    {
        private DACumplimientoRequisito _DACumplimientoRequisito;


        public LCumplimientoRequisito(IConfiguration configuration)
        {
            _DACumplimientoRequisito = new DACumplimientoRequisito();

        }

        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel Modelo)
        {
            try
            {
                var respuesta = await _DACumplimientoRequisito.Agregar(Modelo.ConvertBD());
                Modelo = new CumplimientoRequisitoModel(respuesta);
                return Modelo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CumplimientoRequisitoViewModel> Obtener(int IdCumplimientoRequisito)
        {
            try
            {
                CumplimientoRequisitoViewModel Objeto = await _DACumplimientoRequisito.Obtener(IdCumplimientoRequisito);
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DACumplimientoRequisito.Listar();
                //IEnumerable<CumplimientoRequisitoModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new CumplimientoRequisitoModel(ObjetoBD)).ToList();

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<CumplimientoRequisitoViewModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> ListarPorPlanDesarrolloID(int planDesarrolloID)
        {
            try
            {
          
                var ListaObjetoBD = await _DACumplimientoRequisito.ListarPorPlanDesarrolloID(planDesarrolloID);

              
                return ListaObjetoBD;
            }
            catch (Exception e)
            {

                return new List<CumplimientoRequisitoViewModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> ObtenerAprobadosPorSupervisor(int supervisorID)
        {
            try
            {

                var ListaObjetoBD = await _DACumplimientoRequisito.ObtenerAprobadosPorSupervisor(supervisorID);


                return ListaObjetoBD;
            }
            catch (Exception e)
            {

                return new List<CumplimientoRequisitoViewModel>().AsEnumerable();
            }
        }


        //public async Task<CumplimientoRequisitoModel> Inactivar(int IdCumplimientoRequisito)
        //{
        //    try
        //    {
        //        CumplimientoRequisitoModel Objeto = new CumplimientoRequisitoModel(await _DACumplimientoRequisito.Inactivar(IdCumplimientoRequisito));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo)
        {
            try
            {
                var Objeto = await _DACumplimientoRequisito.Actualizar(modelo.ConvertBD());
                modelo = new CumplimientoRequisitoModel(Objeto);
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

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            try
            {
                bool Objeto = await _DACumplimientoRequisito.Eliminar(IdCumplimientoRequisito);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
