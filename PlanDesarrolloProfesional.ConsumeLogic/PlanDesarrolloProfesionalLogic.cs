using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.ConsumeLogic.ConsumoAPI;
using PlanDesarrolloProfesional.Models.Models.Configuracion;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.ConsumeLogic
{
    public class PlanDesarrolloProfesionalLogic
    {
        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public PlanDesarrolloProfesionalLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<PlanesDesarrolloProfesionalModel> Agregar(PlanesDesarrolloProfesionalModel PlanDesarrolloModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(PlanDesarrolloModel);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.PlanDesarrolloProfesional_Agregar), lista/*, await Token()*/);
            PlanesDesarrolloProfesionalModel Objeto = JsonConvert.DeserializeObject<PlanesDesarrolloProfesionalModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<PlanDesarrolloProfesionalViewModel> Obtener(int IdPlan)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.PlanDesarrolloProfesional_Obtener, IdPlan.ToString())/*, await Token()*/);
            PlanDesarrolloProfesionalViewModel Objeto = JsonConvert.DeserializeObject<PlanDesarrolloProfesionalViewModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<JerarquiasModel> Inactivar(int IdJerarquias)
        //{
        //    var URL = "https://localhost:7287/api/v1/Jerarquias/Inactivar?IdJerarquias=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdJerarquias.ToString())/*, await Token()*/);
        //    JerarquiasModel Objeto = JsonConvert.DeserializeObject<JerarquiasModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<PlanesDesarrolloProfesionalModel> Actualizar(PlanesDesarrolloProfesionalModel PlanDesarrolloModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(PlanDesarrolloModel);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.PlanDesarrolloProfesional_Actualizar), lista/*, await Token()*/);
            PlanesDesarrolloProfesionalModel Objeto = JsonConvert.DeserializeObject<PlanesDesarrolloProfesionalModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<PlanDesarrolloProfesionalViewModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.PlanDesarrolloProfesional_Listar)/*, await Token()*/);
            List<PlanDesarrolloProfesionalViewModel> ListaJerarquiasModel = JsonConvert.DeserializeObject<List<PlanDesarrolloProfesionalViewModel>>(ListaSolicitudeJson);

            return ListaJerarquiasModel;
        }

        public async Task<bool> Eliminar(int IdPlan, string nameclaim)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.PlanDesarrolloProfesional_Eliminar, IdPlan.ToString(), nameclaim)/*, await Token()*/);
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
