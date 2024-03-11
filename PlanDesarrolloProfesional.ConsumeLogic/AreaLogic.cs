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
    public class AreaLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public AreaLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<AreaModel> Agregar(AreaModel AreaModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(AreaModel);
            lista.Add(nameclaim);

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Area_Agregar), lista/*, await Token()*/);
            AreaModel Objeto = JsonConvert.DeserializeObject<AreaModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<AreaModel> Obtener(int IdArea)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Area_Obtener, IdArea.ToString())/*, await Token()*/);
            AreaModel Objeto = JsonConvert.DeserializeObject<AreaModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<AreaModel> Inactivar(int IdArea)
        //{
        //    var URL = "https://localhost:7287/api/v1/Rol/Inactivar?IdArea=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdArea.ToString())/*, await Token()*/);
        //    AreaModel Objeto = JsonConvert.DeserializeObject<AreaModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<AreaModel> Actualizar(AreaModel AreaModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(AreaModel);
            lista.Add(nameclaim);

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Area_Actualizar), lista/*, await Token()*/);
            AreaModel Objeto = JsonConvert.DeserializeObject<AreaModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<AreaModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Area_Listar)/*, await Token()*/);
            List<AreaModel> ListaAreaModel = JsonConvert.DeserializeObject<List<AreaModel>>(ListaSolicitudeJson);

            return ListaAreaModel;
        }

        public async Task<bool> Eliminar(int IdArea, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(IdArea);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Area_Eliminar, IdArea.ToString(), nameclaim)/*, await Token()*/);
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
