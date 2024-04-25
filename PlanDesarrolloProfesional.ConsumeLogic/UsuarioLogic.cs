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
    public class UsuarioLogic
    {

        #region Variables y Constructor

        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;
        //private TokenLogic LToken;
        private IConfiguration IConfiguracion;

        public UsuarioLogic()
        {
            ServicesRequest = new WebServiceDataAccess();
            this.IConfiguracion = IConfiguracion;
            Configuration = new ConfigurationAttribute();
            //LToken = new TokenLogic();
        }

        #endregion Variables y Constructor

        #region Métodos

        public async Task<UsuarioModel> Agregar(UsuarioModel UsuarioModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(UsuarioModel);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_Agregar), lista/*, await Token()*/);
            UsuarioModel Objeto = JsonConvert.DeserializeObject<UsuarioModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<UsuarioAgregarViewModel> AgregarUsuarioAreaJerarquia(UsuarioAgregarViewModel UsuarioViewModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(UsuarioViewModel);
            lista.Add(nameclaim);

            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_AgregarViewModel), lista/*, await Token()*/);
            UsuarioAgregarViewModel Objeto = JsonConvert.DeserializeObject<UsuarioAgregarViewModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<UsuarioModel> Obtener(int IdUsuario)
        {
   
            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_Obtener, IdUsuario.ToString())/*, await Token()*/);
            UsuarioModel Objeto = JsonConvert.DeserializeObject<UsuarioModel>(ObjetoJson);

            return Objeto;
        }
        public async Task<UsuarioModel> ObtenerPorCorreo(string correo)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ObtenerPorCorreo, correo.ToString())/*, await Token()*/);
            UsuarioModel Objeto = JsonConvert.DeserializeObject<UsuarioModel>(ObjetoJson);

            return Objeto;
        }
        public async Task<UsuarioAgregarViewModel> ObtenerUA(int IdUsuario)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ObtenerUA, IdUsuario.ToString())/*, await Token()*/);
            UsuarioAgregarViewModel Objeto = JsonConvert.DeserializeObject<UsuarioAgregarViewModel>(ObjetoJson);

            return Objeto;
        }

        //public async Task<UsuarioModel> Inactivar(int IdUsuario)
        //{
        //    var URL = "https://localhost:7287/api/v1/Usuario/Inactivar?IdUsuario=[Parametro1]";
        //    var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(URL, IdUsuario.ToString())/*, await Token()*/);
        //    UsuarioModel Objeto = JsonConvert.DeserializeObject<UsuarioModel>(ObjetoJson);

        //    return Objeto;
        //}

        public async Task<UsuarioAgregarViewModel> Actualizar(UsuarioAgregarViewModel UsuarioModel, string nameclaim)
        {
            List<object> lista = new List<object>();
            lista.Add(UsuarioModel);
            lista.Add(nameclaim);
            var ObjetoJson = await ServicesRequest.DataRequestPOST(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_Actualizar), lista/*, await Token()*/);
            UsuarioAgregarViewModel Objeto = JsonConvert.DeserializeObject<UsuarioAgregarViewModel>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<UsuarioModel>> Listar()
        {
           
            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_Listar)/*, await Token()*/);
            List<UsuarioModel> ListaUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioModel>>(ListaSolicitudeJson);

            return ListaUsuarioModel;
        }
        public async Task<List<UsuarioViewModel>> ListarVM()
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ListarVM)/*, await Token()*/);
            List<UsuarioViewModel> ListaUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(ListaSolicitudeJson);

            return ListaUsuarioModel;
        }
        public async Task<List<UsuarioModel>> ListarPorSupervisor(int idSupervisor)
        {

            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ListarPorSupervisor, idSupervisor.ToString())/*, await Token()*/);
            List<UsuarioModel> ListaUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioModel>>(ListaSolicitudeJson);

            return ListaUsuarioModel;
        }

        public async Task<bool> Eliminar(int IdUsuario, string nameclaim)
        {
       
            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_Eliminar, IdUsuario.ToString(), nameclaim)/*, await Token()*/);
            bool Objeto = JsonConvert.DeserializeObject<bool>(ObjetoJson);

            return Objeto;
        }

        public async Task<string> ObtenerUltimaAreaPorUsuario(int IdUsuario)
        {

            var ObjetoJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ObtenerUltimaAreaPorUsuario, IdUsuario.ToString())/*, await Token()*/);
            string Objeto = JsonConvert.DeserializeObject<string>(ObjetoJson);

            return Objeto;
        }

        public async Task<List<UsuarioViewModel>> ListarAreasPorUsuario(int IdUsuario)
        {
            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_ListarAreasPorUsuario, IdUsuario.ToString())/*, await Token()*/);
            List<UsuarioViewModel> ListaUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(ListaSolicitudeJson);

            return ListaUsuarioModel;

        }
        

        public async Task<List<UsuarioRuta>> RutaPorUsuario(int IdUsuario)
        {
            var ListaSolicitudeJson = await ServicesRequest.DataRequestGET(Configuration.GetRouteAttribute(AppSettings.APIEndpoints.Usuario_RutaPorUsuario, IdUsuario.ToString())/*, await Token()*/);
            List<UsuarioRuta> ListaUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioRuta>>(ListaSolicitudeJson);

            return ListaUsuarioModel;

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
