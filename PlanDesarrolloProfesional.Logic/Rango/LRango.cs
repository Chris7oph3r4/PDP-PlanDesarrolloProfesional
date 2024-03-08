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
    public class LRango : IRango
    {
        private DARango _DARango;


        public LRango(IConfiguration configuration)
        {
            _DARango = new DARango();

        }

        public async Task<RangoModel> Agregar(RangoModel Modelo)
        {
            try
            {
                var respuesta = await _DARango.Agregar(Modelo.ConvertBD());
                Modelo = new RangoModel(respuesta);
                return Modelo;
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

        public async Task<RangoModel> Actualizar(RangoModel modelo)
        {
            try
            {
                var Objeto = await _DARango.Actualizar(modelo.ConvertBD());
                modelo = new RangoModel(Objeto);
                return modelo;
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

        public async Task<bool> Eliminar(int IdRango)
        {
            try
            {
                bool Objeto = await _DARango.Eliminar(IdRango);
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
