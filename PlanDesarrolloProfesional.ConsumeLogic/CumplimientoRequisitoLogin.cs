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
    public class CumplimientoRequisitoLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        private IConfiguration IConfiguracion;

        public CumplimientoRequisitoLogic(IConfiguration configuracion)
        {
            ServicesRequest = new WebServiceDataAccess();
            IConfiguracion = configuracion;
            Configuration = new ConfigurationAttribute();
        }

        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel modelo)
        {
            var objetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Agregar), modelo);
            CumplimientoRequisitoModel objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(objetoJson);
            return objeto;
        }

        public async Task<CumplimientoRequisitoModel> Obtener(int IdCumplimientoRequisito)
        {
            var objetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Obtener, IdCumplimientoRequisito.ToString()));
            CumplimientoRequisitoModel objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(objetoJson);
            return objeto;
        }

        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo)
        {
            var objetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Actualizar), modelo);
            CumplimientoRequisitoModel objeto = JsonConvert.DeserializeObject<CumplimientoRequisitoModel>(objetoJson);
            return objeto;
        }

        public async Task<List<CumplimientoRequisitoModel>> Listar()
        {
            var listaJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Listar));
            List<CumplimientoRequisitoModel> lista = JsonConvert.DeserializeObject<List<CumplimientoRequisitoModel>>(listaJson);
            return lista;
        }

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            var objetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.CumplimientoRequisito_Eliminar, IdCumplimientoRequisito.ToString()));
            bool resultado = JsonConvert.DeserializeObject<bool>(objetoJson);
            return resultado;
        }
    }
}
