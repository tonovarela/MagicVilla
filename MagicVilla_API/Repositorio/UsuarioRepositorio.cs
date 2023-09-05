using MagicVilla_API.Datos;
using MagicVilla_API.Model.DTO;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using MagicVilla_API.Modelss.DTO;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_API.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
         private readonly AppDBContext _ctx;
        private string _secretKey;
        public UsuarioRepositorio(AppDBContext db,IConfiguration configuration)
        {
            _ctx = db;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool isUsuarioUnico(string userName)
        {
         return _ctx.Usuarios.Any(u => u.UserName.ToLower() == userName.ToLower());          
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var usuario = await _ctx.Usuarios.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDTO.Username.ToLower() && u.Password == loginRequestDTO.Password);
            if (usuario != null)
            {
                return new LoginResponseDTO
                {
                    Token = "",
                    Usuario = null
                };          
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Rol),
                }
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new()
            {

                Token = tokenHandler.WriteToken(token),
                Usuario = usuario
            };
            return loginResponseDTO;

        }

        

        public async Task<Usuario> Registrar(RegistroRequestDTO registroRequestDTO)
        {
            Usuario usuario = new()
            {
                UserName = registroRequestDTO.UserName,
                Password = registroRequestDTO.Password,
                Nombres = registroRequestDTO.Nombres,
                Rol= registroRequestDTO.Rol
            };
            await _ctx.Usuarios.AddAsync(usuario);
            await _ctx.SaveChangesAsync();
            usuario.Password = "";
            return usuario;
        }
    }
}
