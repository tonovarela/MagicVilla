using MagicVilla_Utilidad;
using MagicVillaWeb.Models;
using MagicVillaWeb.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace MagicVillaWeb.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            responseModel = new();
        }
        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url!);
                if (apiRequest.Datos != null)
                {                 
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Datos), Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiTipo)
                {
                    case DS.APITipo.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case DS.APITipo.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case DS.APITipo.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case DS.APITipo.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                //var response = JsonConvert.DeserializeObject<T>(apiContent);
                //return response;

                try
                {
                    APIResponse response = JsonConvert.DeserializeObject<APIResponse>(apiContent); ;
                    if (apiResponse.StatusCode == HttpStatusCode.BadRequest || apiResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        response.statusCode = HttpStatusCode.BadRequest;
                        response.isSuccess = false;
                        var res = JsonConvert.SerializeObject(response);
                        var obj= JsonConvert.DeserializeObject<T>(res);
                        return obj;
                    }
                }
                catch (Exception ec)
                {
                    var errorResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return errorResponse;
                }
                var ApiResponse= JsonConvert.DeserializeObject<T>(apiContent);
                return ApiResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    Resultado = new List<string> {  Convert.ToString(ex.Message)},
                    isSuccess = false

                };
                var res = JsonConvert.SerializeObject(dto);
                var responseEx = JsonConvert.DeserializeObject<T>(res);
                return responseEx!;
            }
        }
    }
}
