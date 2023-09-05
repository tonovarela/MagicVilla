using MagicVilla_API.Model.DTO;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using MagicVilla_API.Modelss.DTO;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {

        bool isUsuarioUnico(string userName);


        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<Usuario> Registrar(RegistroRequestDTO registroRequestDTO);


    }
}
