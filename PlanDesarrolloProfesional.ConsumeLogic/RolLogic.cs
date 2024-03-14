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
    public class RolLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public RolLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<RolModel> Agregar(RolModel RolModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_Agregar), RolModel/*, await Token()*/);
            RolModel Objeto = JsonConvert.DeserializeObject<RolModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<RolModel> Obtener(int IdRol)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_Obtener, IdRol.ToString())/*, await Token()*/);
            RolModel Objeto = JsonConvert.DeserializeObject<RolModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<RolModel> Inactivar(int IdRol)
        //{
        //    var URL = "https://localhost:7287/api/v1/Rol/Inactivar?IdRol=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdRol.ToString())/*, await Token()*/);
        //    RolModel Objeto = JsonConvert.DeserializeObject<RolModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<RolModel> Actualizar(RolModel RolModel)
        {

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_Actualizar), RolModel/*, await Token()*/);
            RolModel Objeto = JsonConvert.DeserializeObject<RolModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<RolModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_Listar)/*, await Token()*/);
            List<RolModel> ListaRolModel = JsonConvert.DeserializeObject<List<RolModel>>(ListaSolicitudeJson);

            return ListaRolModel;
        }

        public async Task<bool> Eliminar(int IdRol)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_Eliminar, IdRol.ToString())/*, await Token()*/);
            bool Objeto = JsonConvert.DeserializeObject<bool>(ObjetoJson);

            return Objeto;
        }

        public async Task<string> ObtenerNombreDelRol(int IdRol)
        {
         
                // Construir el URL reemplazando el placeholder {id} con el IdRol
             var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Rol_ObtenerNombreDeLRol, IdRol.ToString())/*, await Token()*/);
            // Deserializar la respuesta a un string, asumiendo que el endpoint devuelve directamente el nombre del rol como una cadena de texto
            string Objeto = JsonConvert.DeserializeObject<string>(ObjetoJson);

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
