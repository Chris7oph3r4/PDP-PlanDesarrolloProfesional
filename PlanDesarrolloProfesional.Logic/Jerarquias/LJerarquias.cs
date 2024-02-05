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
    public class LJerarquias : IJerarquias
    {
        private DAJerarquias _DAJerarquias;


        public LJerarquias(IConfiguration configuration)
        {
            _DAJerarquias = new DAJerarquias();
       
        }

        public async Task<JerarquiasModel> Agregar(JerarquiasModel Modelo)
        {
            try
            {
                var respuesta = await _DAJerarquias.Agregar(Modelo.ConvertBD());
                Modelo = new JerarquiasModel(respuesta);
                return Modelo;
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

        public async Task<JerarquiasModel> Actualizar(JerarquiasModel modelo)
        {
            try
            {
                var Objeto = await _DAJerarquias.Actualizar(modelo.ConvertBD());
                modelo = new JerarquiasModel(Objeto);
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

        public async Task<bool> Eliminar(int IdJerarquias)
        {
            try
            {
                bool Objeto = await _DAJerarquias.Eliminar(IdJerarquias);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
