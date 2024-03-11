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
    public class BitacoraLogic
    {
        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public BitacoraLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos
        
        public async Task<List<BitacoraModel>> Listar()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Bitacora_Listar)/*, await Token()*/);
            List<BitacoraModel> ListaBitacora = JsonConvert.DeserializeObject<List<BitacoraModel>>(ListaSolicitudeJson);

            return ListaBitacora;
        }

        #endregion 
    }
}
