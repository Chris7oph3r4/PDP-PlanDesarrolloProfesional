using Microsoft.Extensions.Configuration;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarRutaloProfesional.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LRuta : IRuta
    {
        private DARuta _DARuta;


        public LRuta(IConfiguration configuration)
        {
            _DARuta = new DARuta();

        }

        public async Task<RutaModel> Agregar(RutaModel Modelo)
        {
            try
            {
                var respuesta = await _DARuta.Agregar(Modelo.ConvertBD());
                Modelo = new RutaModel(respuesta);
                return Modelo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RutaModel> Obtener(int IdRuta)
        {
            try
            {
                RutaModel Objeto = new RutaModel(await _DARuta.Obtener(IdRuta));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RutaModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DARuta.Listar();
                IEnumerable<RutaModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new RutaModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<RutaModel>().AsEnumerable();
            }
        }

        //public async Task<RutaModel> Inactivar(int IdRuta)
        //{
        //    try
        //    {
        //        RutaModel Objeto = new RutaModel(await _DARuta.Inactivar(IdRuta));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<RutaModel> Actualizar(RutaModel modelo)
        {
            try
            {
                var Objeto = await _DARuta.Actualizar(modelo.ConvertBD());
                modelo = new RutaModel(Objeto);
                return modelo;
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

        public async Task<bool> Eliminar(int IdRuta)
        {
            try
            {
                bool Objeto = await _DARuta.Eliminar(IdRuta);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
