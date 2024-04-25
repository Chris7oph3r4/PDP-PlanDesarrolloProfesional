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
    public class LPlanDesarrolloProfesional :IPlanDesarrolloProfesional
    {
        private DAPlanDesarrolloProfesional _DAPlanDesarrollo;
        private int _idUsuario;

        public LPlanDesarrolloProfesional()
        {
            _DAPlanDesarrollo = new DAPlanDesarrolloProfesional();
        }

        public async Task<PlanesDesarrolloProfesionalModel> Agregar(List<object> Modelo)
        {
            PlanesDesarrolloProfesionalModel Model;
            try
            {
                var respuesta = await _DAPlanDesarrollo.Agregar(JsonConvert.DeserializeObject<PlanesDesarrolloProfesionalModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                Model = new PlanesDesarrolloProfesionalModel(respuesta);
                return Model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<PlanDesarrolloProfesionalViewModel> Obtener(int IdPlan)
        {
            try
            {
                PlanDesarrolloProfesionalViewModel Objeto = await _DAPlanDesarrollo.Obtener(IdPlan);
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAPlanDesarrollo.Listar();
                //IEnumerable<PlanDesarrolloProfesionalViewModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new PlanDesarrolloProfesionalViewModel(ObjetoBD)).ToList();

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<PlanDesarrolloProfesionalViewModel>().AsEnumerable();
            }
        }
        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> ListarPorUsuario(int usuarioID)
        {
            try
            {
                var ListaObjetoBD = await _DAPlanDesarrollo.ListarPorUsuario(usuarioID);
                //IEnumerable<PlanDesarrolloProfesionalViewModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new PlanDesarrolloProfesionalViewModel(ObjetoBD)).ToList();

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<PlanDesarrolloProfesionalViewModel>().AsEnumerable();
            }
        }
        public async Task<PlanesDesarrolloProfesionalModel> Actualizar(List<object> modelo)
        {
            PlanesDesarrolloProfesionalModel model;
            try
            {
                var Objeto = await _DAPlanDesarrollo.Actualizar(JsonConvert.DeserializeObject<PlanesDesarrolloProfesionalModel>(modelo[0]?.ToString()).ConvertBD(), modelo[1]?.ToString());
                model = new PlanesDesarrolloProfesionalModel(Objeto);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> Eliminar(int IdPlan, string nameclaim)
        {
            try
            {

                bool Objeto = await _DAPlanDesarrollo.Eliminar(IdPlan, nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<int> ObtenerCantidadPlanesPorUsuario(int idUsuario)
        {
            return await _DAPlanDesarrollo.ObtenerCantidadPlanesPorUsuario(idUsuario);
        }

        public async Task<string> ObtenerUltimoRangoPorColaborador(int colaboradorId)
        {
            return await _DAPlanDesarrollo.ObtenerUltimoRangoPorColaborador(colaboradorId);
        }

        public async Task<int> ContarPlanesFinalizadosPorColaborador(int colaboradorId)
        {
            return await _DAPlanDesarrollo.ContarPlanesFinalizadosPorColaborador(colaboradorId);
        }

        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> ObtenerPlanesPorColaborador(int colaboradorId)
        {
            try
            {
                var ListaObjetoBD = await _DAPlanDesarrollo.ObtenerPlanesPorColaborador(colaboradorId);

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                return new List<PlanDesarrolloProfesionalViewModel>().AsEnumerable();
            }
        }

        public async Task<string> ObtenerNombreRutaPorColaboradorId(int colaboradorId)
        {
            return await _DAPlanDesarrollo.ObtenerNombreRutaPorColaboradorId(colaboradorId);
        }
    }
}
