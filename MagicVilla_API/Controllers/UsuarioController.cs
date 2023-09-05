using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using MagicVilla_API.Modelss.DTO;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private APIResponse _response;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _response = new APIResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _usuarioRepositorio.Login(model);
            if (loginResponse.Usuario == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.Resultado = "Usuario o contraseña incorrectos";
                _response.isSuccess = false;
                return BadRequest(_response);
            }

            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.OK;
            _response.Resultado = loginResponse;
            return Ok(_response);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistroRequestDTO model)
        {
            bool isUsuarioUnico = _usuarioRepositorio.isUsuarioUnico(model.UserName);
            if (!isUsuarioUnico)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.Resultado = "El usuario ya existe";
                _response.isSuccess = false;
                return BadRequest(_response);
            }

            var usuario = await _usuarioRepositorio.Registrar(model);
            if (usuario == null)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.Resultado = "Error al registrar";
                return BadRequest(_response);
            }
            _response.statusCode=HttpStatusCode.OK;
            _response.isSuccess = true;
            _response.Resultado= usuario;
            return Ok(_response);
        }
    }
}
