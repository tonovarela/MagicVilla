using MagicVilla_Utilidad;
using MagicVilla_Utilidad.DTO;
using MagicVillaWeb.Models;
using MagicVillaWeb.Services.IServices;
using Microsoft.Extensions.Configuration;

namespace MagicVillaWeb.Services
{
    public class NumeroVillaService : BaseService, INumeroVillaService
    {
        public readonly IHttpClientFactory httpClient;
        private string _villaUrl;
        public NumeroVillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {

            _villaUrl = configuration.GetValue<string>("ServiceURL:API_URL");
            _httpClient = httpClient;
            

        }
        public Task<T> Actualizar<T>(NumeroVillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _villaUrl + "/api/NumeroVilla/"+dto.VillaNo
            });

        }

        public Task<T> Crear<T>(NumeroVillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.POST,
                Datos =dto,
                Url = _villaUrl+"/api/Numerovilla"
            });
        }

        public Task<T> obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.GET,                
                Url = _villaUrl + "/api/NumeroVilla/"+id
            });
        }

      
        public Task<T> obtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.GET,                
                Url = _villaUrl + "/api/NumeroVilla"
            });
        }

        public Task<T> Remover<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiTipo = DS.APITipo.DELETE,               
                Url = _villaUrl + "/api/NumeroVilla/"+id
            });
        }
    }
}
