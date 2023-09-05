

using MagicVilla_Utilidad.DTO;

namespace MagicVillaWeb.Services.IServices
{
    public interface INumeroVillaService 
    {
        Task<T> obtenerTodos<T>();
        Task<T> obtener<T>(int id);
        Task<T> Crear<T>(NumeroVillaCreateDTO dto);

        Task<T> Actualizar<T>(NumeroVillaUpdateDTO dto);

        Task<T> Remover<T>(int id);   
    }
}
