using static MagicVilla_Utilidad.DS;

namespace MagicVillaWeb.Models
{
    public class APIRequest
    {

        public APITipo ApiTipo { get; set; } = APITipo.GET;

        public string? Url { get; set; }

        public object? Datos { get; set; }
    }
}
