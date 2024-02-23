﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.ConsumeLogic.ConsumoAPI;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarrolloProfesional.Models.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.ConsumeLogic
{
    public class RangoLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public RangoLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<RangoModel> Agregar(RangoModel RangoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rango_Agregar), RangoModel/*, await Token()*/);
            RangoModel Objeto = JsonConvert.DeserializeObject<RangoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<RangoModel> Obtener(int IdRango)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rango_Obtener, IdRango.ToString())/*, await Token()*/);
            RangoModel Objeto = JsonConvert.DeserializeObject<RangoModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<RangoModel> Inactivar(int IdRango)
        //{
        //    var URL = "https://localhost:7287/api/v1/Jerarquias/Inactivar?IdRango=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdRango.ToString())/*, await Token()*/);
        //    RangoModel Objeto = JsonConvert.DeserializeObject<RangoModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<RangoModel> Actualizar(RangoModel RangoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rango_Actualizar), RangoModel/*, await Token()*/);
            RangoModel Objeto = JsonConvert.DeserializeObject<RangoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<RangoModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rango_Listar)/*, await Token()*/);
            List<RangoModel> ListaJerarquiasModel = JsonConvert.DeserializeObject<List<RangoModel>>(ListaSolicitudeJson);

            return ListaJerarquiasModel;
        }

        public async Task<bool> Eliminar(int IdRango)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rango_Eliminar, IdRango.ToString())/*, await Token()*/);
            bool Objeto = JsonConvert.DeserializeObject<bool>(ObjetoJson);

            return Objeto;
        }
        #endregion Métodos

        #region Funciones

        //public async Task<string> Token()
        //{


        //    var Token = await LToken.ObtenerToken();

        //    return Token.Token;
        //}



        #endregion Funciones
    }
}