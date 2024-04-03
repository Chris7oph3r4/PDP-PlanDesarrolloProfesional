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
    public class RequisitoLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public RequisitoLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<RequisitoModel> Agregar(RequisitoModel RequisitoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_Agregar), RequisitoModel/*, await Token()*/);
            RequisitoModel Objeto = JsonConvert.DeserializeObject<RequisitoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<RequisitoModel> Obtener(int IdRequisito)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_Obtener, IdRequisito.ToString())/*, await Token()*/);
            RequisitoModel Objeto = JsonConvert.DeserializeObject<RequisitoModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<RequisitoModel> Inactivar(int IdRequisito)
        //{
        //    var URL = "https://localhost:7287/api/v1/Requisito/Inactivar?IdRequisito=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdRequisito.ToString())/*, await Token()*/);
        //    RequisitoModel Objeto = JsonConvert.DeserializeObject<RequisitoModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<RequisitoModel> Actualizar(RequisitoModel RequisitoModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_Actualizar), RequisitoModel/*, await Token()*/);
            RequisitoModel Objeto = JsonConvert.DeserializeObject<RequisitoModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<RequisitoModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_Listar)/*, await Token()*/);
            List<RequisitoModel> ListaRequisitoModel = JsonConvert.DeserializeObject<List<RequisitoModel>>(ListaSolicitudeJson);

            return ListaRequisitoModel;
        }

        public async Task<List<RequisitoModel>> RequisitoPorRango(int idRango)
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_RequisitoPorRango, idRango.ToString())/*, await Token()*/);
            List<RequisitoModel> ListaRequisitosModel = JsonConvert.DeserializeObject<List<RequisitoModel>>(ListaSolicitudeJson);

            return ListaRequisitosModel;
        }

        public async Task<bool> Eliminar(int IdRequisito)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Requisito_Eliminar, IdRequisito.ToString())/*, await Token()*/);
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
