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
    public class LArea : IArea
    {
        private DAArea _DAArea;


        public LArea(IConfiguration configuration)
        {
            _DAArea = new DAArea();

        }

        public async Task<AreaModel> Agregar(AreaModel Modelo)
        {
            try
            {
                var respuesta = await _DAArea.Agregar(Modelo.ConvertBD());
                Modelo = new AreaModel(respuesta);
                return Modelo;
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

        public async Task<AreaModel> Actualizar(AreaModel modelo)
        {
            try
            {
                var Objeto = await _DAArea.Actualizar(modelo.ConvertBD());
                modelo = new AreaModel(Objeto);
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

        public async Task<bool> Eliminar(int IdArea)
        {
            try
            {
                bool Objeto = await _DAArea.Eliminar(IdArea);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
