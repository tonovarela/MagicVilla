

using MagicVilla_Utilidad.DTO;

namespace MagicVillaWeb.Services.IServices
{
    public interface IVillaService 
    {
        Task<T> obtenerTodos<T>();
        Task<T> obtener<T>(int id);
        Task<T> Crear<T>(VillaCreateDTO dto);

        Task<T> Actualizar<T>(VillaUpdateDTO dto);

        Task<T> Remover<T>(int id);   
    }
}
