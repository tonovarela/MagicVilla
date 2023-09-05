using MagicVillaWeb.Models;

namespace MagicVillaWeb.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse  responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest APIRequest);
    }
}
