using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace PlanDesarrolloProfesional.ConsumeLogic.ConsumoAPI
{
    public class WebServiceDataAccess
    {
        #region Variables y Constructor
        private HttpResponseMessage RespuestaAPI;

        public WebServiceDataAccess()
        {
            RespuestaAPI = new HttpResponseMessage();
        }
        #endregion

        #region Métodos
        public async Task<string> DataRequestGET(string URL, string Token)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.GetAsync(URL);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();

                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        public async Task<string> DataRequestGET(string URL)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.GetAsync(URL);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();

                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, object Model)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);

                //Convertimos el objeto en peticion, se da la codificacion, y el mediatype
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();


                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, IEnumerable<object> ListModel)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);

                //Convertimos el objeto en peticion, se da la codificacion, y el mediatype
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(ListModel), Encoding.UTF8, "application/json");

                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();


                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, IEnumerable<object> ListaModel, string Token)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                //Convertimos el objeto en peticion, se da la codificacion, y el mediatype
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(ListaModel), Encoding.UTF8, "application/json");

                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();

                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, object Model, string Token)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                //Se configura la llamada al API
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                //Convertimos el objeto en peticion, se da la codificacion, y el mediatype
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");
                var json = JsonConvert.SerializeObject(Model);
                // Ejecutar y guardar respuesta
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);

                //Se obtiene el content del HTTPResponse proveniente del API
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();

                //Se retorna el resultado en formato JSON
                return ContentResult;
            }
        }

        //public async Task<string> DataRequestPOSTToken(string URL, Peticion_TokenModel Model)
        //{
        //    var client = new RestClient(URL);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("Contrasenna", Model.Contrasenna);
        //    request.AddParameter("Usuario", Model.Usuario);
        //    //request.AddParameter("grant_type", Model.grant_type);
        //    IRestResponse response = client.Execute(request);

        //    return response.Content;
        //}

        #endregion
    }
}
