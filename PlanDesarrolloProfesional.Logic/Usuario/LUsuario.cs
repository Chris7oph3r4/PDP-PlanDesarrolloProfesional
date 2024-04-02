﻿using Microsoft.AspNetCore.Mvc;
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
    public class LUsuario : IUsuario
    {
        private DAUsuario _DAUsuario;


        public LUsuario(IConfiguration configuration)
        {
            _DAUsuario = new DAUsuario();
       
        }

        public async Task<UsuarioModel> Agregar(List<object> Modelo)
        {
            UsuarioModel model;
            try
            {
                var respuesta = await _DAUsuario.Agregar(JsonConvert.DeserializeObject<UsuarioModel>(Modelo[0]?.ToString()).ConvertBD(), Modelo[1]?.ToString());
                model = new UsuarioModel(respuesta);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<UsuarioAgregarViewModel> AgregarUsuarioAreaJerarquia(List<object> Model)
        {
            UsuarioAgregarViewModel Modelo;
            string nameclaim;
            try
            {
                Modelo = JsonConvert.DeserializeObject<UsuarioAgregarViewModel>(Model[0]?.ToString());
                nameclaim = Model[1]?.ToString();

                Usuario usuario = new Usuario
                {
                    Nombre = Modelo.Nombre,
                    RolID = Modelo.RolID,
                    JerarquiaID = Modelo.JerarquiaID,
                    Descripcion = Modelo.Descripcion,
                    Correo = Modelo.Correo,
                    CodigoDaloo = Modelo.CodigoDaloo
                };
                var respuesta = await _DAUsuario.Agregar(usuario,nameclaim);
                Modelo.UsuarioID = respuesta.UsuarioID;
                var respuestaArea = await _DAUsuario.AgregarAreas(Modelo, nameclaim);
                var respuestaSupervisor = await _DAUsuario.AgregarSupervisor(Modelo, nameclaim);
                
                return respuestaSupervisor;
             
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UsuarioModel> Obtener(int IdUsuario)
        {
            try
            {
                UsuarioModel Objeto = new UsuarioModel(await _DAUsuario.Obtener(IdUsuario));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<UsuarioModel> ObtenerPorCorreo(string correo)
        {
            try
            {
                UsuarioModel Objeto = new UsuarioModel(await _DAUsuario.ObtenerPorCorreo(correo));
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<UsuarioAgregarViewModel> ObtenerUA(int IdUsuario)
        {
            try
            {
                UsuarioAgregarViewModel Objeto = await _DAUsuario.ObtenerUA(IdUsuario);
                return Objeto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<IEnumerable<UsuarioModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAUsuario.Listar();
                IEnumerable<UsuarioModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new UsuarioModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<UsuarioModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<UsuarioViewModel>> ListarVM()
        {
            try
            {
                var ListaObjetoBD = await _DAUsuario.ListarVM();

                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<UsuarioViewModel>().AsEnumerable();
            }
        }

        //public async Task<UsuarioModel> Inactivar(int IdUsuario)
        //{
        //    try
        //    {
        //        UsuarioModel Objeto = new UsuarioModel(await _DAUsuario.Inactivar(IdUsuario));
        //        return Objeto;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<UsuarioAgregarViewModel> Actualizar(UsuarioAgregarViewModel modelo)
        //{
        //    try
        //    {
        //        var Objeto = await _DAUsuario.Actualizar(modelo.ConvertBD());
        //        modelo = new UsuarioModel(Objeto);
        //        return modelo;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}



        //public async Task<IEnumerable<UsuarioViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    try
        //    {
        //        var Lista = await _DAPUsuario.ListarPorUsuario(IdUsuario);

        //        return Lista;
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<UsuarioViewModel>().AsEnumerable();
        //    }
        //}

        public async Task<bool> Eliminar(int IdUsuario, string nameclaim)
        {
            try
            {
                
                bool Objeto = await _DAUsuario.Eliminar(IdUsuario, nameclaim);
                return Objeto;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<UsuarioAgregarViewModel> Actualizar(List<object> model)
        {
            UsuarioAgregarViewModel modelo;
            string nameclaim;
            try
            {
                modelo = JsonConvert.DeserializeObject<UsuarioAgregarViewModel>(model[0]?.ToString());
                nameclaim = model[1]?.ToString();

                List<int> areasOriginales = await _DAUsuario.ObtenerAreasActuales(modelo.UsuarioID);
                List<int> areasRecibidas = modelo.AreasID;
                List<int> nuevasAreas = areasRecibidas.Except(areasOriginales).ToList();
                List<int> areasPorEliminar = areasOriginales.Except(areasRecibidas).ToList();

                var actualizarSupervisor = await _DAUsuario.ActualizarSupervisorUsuario(modelo, nameclaim);

                if (nuevasAreas.Count() != 0)
                {
                    var respuestaArea = await _DAUsuario.AgregarAreas(modelo, nameclaim);
                    
                }
                if (areasPorEliminar.Count() != 0)
                {
                    var eliminarUsuarioArea = await _DAUsuario.EliminarUsuarioArea(areasPorEliminar, nameclaim);
                    
                }
                

                Usuario usuario = new Usuario
                {
                    UsuarioID = modelo.UsuarioID,
                    Nombre = modelo.Nombre,
                    RolID = modelo.RolID,
                    JerarquiaID = modelo.JerarquiaID,
                    Descripcion = modelo.Descripcion,
                    Correo = modelo.Correo,
                    CodigoDaloo = modelo.CodigoDaloo
                };
                var modificarUsuarioArea = await _DAUsuario.ActualizarUsuario(usuario, nameclaim);

                var usuarioActualizado = await _DAUsuario.ObtenerUA(modelo.UsuarioID);

                return usuarioActualizado;


            }
            catch (Exception)
            {

                return null;
            }
            
            throw new NotImplementedException();
        }
    }
}
