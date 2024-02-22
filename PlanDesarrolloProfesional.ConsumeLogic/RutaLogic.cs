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
    public class RutaLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public RutaLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<RutaModel> Agregar(RutaModel RutaModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Ruta_Agregar), RutaModel/*, await Token()*/);
            RutaModel Objeto = JsonConvert.DeserializeObject<RutaModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<RutaModel> Obtener(int IdRuta)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Ruta_Obtener, IdRuta.ToString())/*, await Token()*/);
            RutaModel Objeto = JsonConvert.DeserializeObject<RutaModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<RutaModel> Inactivar(int IdRuta)
        //{
        //    var URL = "https://localhost:7287/api/v1/Rol/Inactivar?IdRuta=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdRuta.ToString())/*, await Token()*/);
        //    RutaModel Objeto = JsonConvert.DeserializeObject<RutaModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<RutaModel> Actualizar(RutaModel RutaModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Ruta_Actualizar), RutaModel/*, await Token()*/);
            RutaModel Objeto = JsonConvert.DeserializeObject<RutaModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<RutaModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Ruta_Listar)/*, await Token()*/);
            List<RutaModel> ListaRutaModel = JsonConvert.DeserializeObject<List<RutaModel>>(ListaSolicitudeJson);

            return ListaRutaModel;
        }

        public async Task<bool> Eliminar(int IdRuta)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Ruta_Eliminar, IdRuta.ToString())/*, await Token()*/);
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
