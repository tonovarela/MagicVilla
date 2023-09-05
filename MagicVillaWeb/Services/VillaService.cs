using MagicVilla_Utilidad;
using MagicVilla_Utilidad.DTO;
using MagicVillaWeb.Models;
using MagicVillaWeb.Services.IServices;

namespace MagicVillaWeb.Services
{
    public class VillaService : BaseService, IVillaService
    {
        public readonly IHttpClientFactory httpClient;
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {

            _villaUrl = configuration.GetValue<string>("ServiceURL:API_URL");
            _httpClient = httpClient;
            

        }
        public Task<T> Actualizar<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _villaUrl + "/api/villa/"+dto.Id
            });

        }

        public Task<T> Crear<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.POST,
                Datos =dto,
                Url = _villaUrl+"/api/villa"
            });
        }

        public Task<T> obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.GET,                
                Url = _villaUrl + "/api/villa/"+id
            });
        }

      
        public Task<T> obtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.GET,                
                Url = _villaUrl + "/api/villa"
            });
        }

        public Task<T> Remover<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.DELETE,               
                Url = _villaUrl + "/api/villa/"+id
            });
        }
    }
}
