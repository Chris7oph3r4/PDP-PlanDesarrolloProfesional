//using Models;
//using Newtonsoft.Json;
//using PedidosWeb.Models;

//namespace PlanDesarrolloProfesional.ConsumeLogic.ConsumoAPI
//{
//    public class TokenLogic
//    {
//        #region Variables y Constructor
//        private WebServiceDataAccess ServicesRequest;

//        public TokenLogic()
//        {
//            ServicesRequest = new WebServiceDataAccess();
//        }
//        #endregion

//        #region Métodos
//        public async Task<Respuesta_TokenModel> ObtenerToken()
//        {
//            Peticion_TokenModel TokenModel = new Peticion_TokenModel();
//            TokenModel.Usuario = "1";
//            TokenModel.Contrasenna = "2";
//            string Url = "https://localhost:7287/api/v1/Token";
//            var PeticionTokenJson = await ServicesRequest.DataRequestPOSTToken(Url, TokenModel);
//            Respuesta_TokenModel RespuestaToken = JsonConvert.DeserializeObject<Respuesta_TokenModel>(PeticionTokenJson);

//            return RespuestaToken;
//        }
//        #endregion

//    }
//}
