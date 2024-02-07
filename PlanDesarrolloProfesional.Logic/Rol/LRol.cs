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
    public class LRol : IRol
    {
        private DARol _DARol;


        public LRol(IConfiguration configuration)
        {
            _DARol = new DARol();

        }

        public async Task<RolModel> Agregar(RolModel Modelo)
        {
            try
            {
                var respuesta = await _DARol.Agregar(Modelo.ConvertBD());
                Modelo = new RolModel(respuesta);
                return Modelo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RolModel> Obtener(int IdRol)
        {
            try
            {
                RolModel Objeto = new RolModel(await _DARol.Obtener(IdRol));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RolModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DARol.Listar();
                IEnumerable<RolModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new RolModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<RolModel>().AsEnumerable();
            }
        }

        //public async Task<RolModel> Inactivar(int IdRol)
        //{
        //    try
        //    {
        //        RolModel Objeto = new RolModel(await _DARol.Inactivar(IdRol));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<RolModel> Actualizar(RolModel modelo)
        {
            try
            {
                var Objeto = await _DARol.Actualizar(modelo.ConvertBD());
                modelo = new RolModel(Objeto);
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

        public async Task<bool> Eliminar(int IdRol)
        {
            try
            {
                bool Objeto = await _DARol.Eliminar(IdRol);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
