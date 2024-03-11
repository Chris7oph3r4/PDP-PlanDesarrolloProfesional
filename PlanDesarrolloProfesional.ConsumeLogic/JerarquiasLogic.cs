using Microsoft.Extensions.Configuration;
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
    public class JerarquiasLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public JerarquiasLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<JerarquiasModel> Agregar(JerarquiasModel JerarquiasModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(JerarquiasModel);
            lista.Add(nameclaim);

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Jerarquias_Agregar), lista/*, await Token()*/);
            JerarquiasModel Objeto = JsonConvert.DeserializeObject<JerarquiasModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<JerarquiasModel> Obtener(int IdJerarquias)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Jerarquias_Obtener, IdJerarquias.ToString())/*, await Token()*/);
            JerarquiasModel Objeto = JsonConvert.DeserializeObject<JerarquiasModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<JerarquiasModel> Inactivar(int IdJerarquias)
        //{
        //    var URL = "https://localhost:7287/api/v1/Rol/Inactivar?IdJerarquias=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdJerarquias.ToString())/*, await Token()*/);
        //    JerarquiasModel Objeto = JsonConvert.DeserializeObject<JerarquiasModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<JerarquiasModel> Actualizar(JerarquiasModel JerarquiasModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(JerarquiasModel);
            lista.Add(nameclaim);

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Jerarquias_Actualizar), lista/*, await Token()*/);
            JerarquiasModel Objeto = JsonConvert.DeserializeObject<JerarquiasModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<JerarquiasModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Jerarquias_Listar)/*, await Token()*/);
            List<JerarquiasModel> ListaJerarquiasModel = JsonConvert.DeserializeObject<List<JerarquiasModel>>(ListaSolicitudeJson);

            return ListaJerarquiasModel;
        }

        public async Task<bool> Eliminar(int IdJerarquias, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(IdJerarquias);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Jerarquias_Eliminar, IdJerarquias.ToString(), nameclaim)/*, await Token()*/);
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
