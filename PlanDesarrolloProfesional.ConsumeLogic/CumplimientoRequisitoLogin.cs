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
    public class CumplimientoRequisitoLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public CumplimientoRequisitoLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel CumplimientoRequisitoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Agregar), CumplimientoRequisitoModel/*, await Token()*/);
            CumplimientoRequisitoModel Objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<CumplimientoRequisitoModel> Obtener(int IdCumplimientoRequisito)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Obtener, IdCumplimientoRequisito.ToString())/*, await Token()*/);
            CumplimientoRequisitoModel Objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<CumplimientoRequisitoModel> Inactivar(int IdCumplimientoRequisito)
        //{
        //    var URL = "https://localhost:7287/api/v1/Requisito/Inactivar?IdCumplimientoRequisito=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdCumplimientoRequisito.ToString())/*, await Token()*/);
        //    CumplimientoRequisitoModel Objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel CumplimientoRequisitoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Actualizar), CumplimientoRequisitoModel/*, await Token()*/);
            CumplimientoRequisitoModel Objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<CumplimientoRequisitoModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Listar)/*, await Token()*/);
            List<CumplimientoRequisitoModel> ListaRequisitoModel = JsonConvert.DeserializeObject<List<CumplimientoRequisitoModel>>(ListaSolicitudeJson);

            return ListaRequisitoModel;
        }

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Eliminar, IdCumplimientoRequisito.ToString())/*, await Token()*/);
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
