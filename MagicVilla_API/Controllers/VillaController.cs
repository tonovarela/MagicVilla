
using System.Net;
using AutoMapper;

using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;
using MagicVilla_Utilidad.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace MagicVilla_API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public VillaController(ILogger<VillaController> logger, IVillaRepositorio villaRepo, IMapper mapper)
        {
            _villaRepo = villaRepo;
            _logger = logger;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villas = await _villaRepo.Listar();
                _response.Resultado = _mapper.Map<IEnumerable<VillaDTO>>(villas);
                _response.statusCode = HttpStatusCode.OK;
                _response.isSuccess = true;
                return Ok(_response);
                
            }
            catch (Exception ex)
            {
             return this.enviarExcepcion(ex.ToString());
            }

        }


        [HttpGet("{id}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> porID(int id)
        {
            _response.isSuccess = false;
            if (id <= 0)
            {
                _logger.LogError("El id es erroreo");
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villa = await _villaRepo.Obtener(v => v.Id == id);
            if (villa == null)
            {
                _response.statusCode = HttpStatusCode.NotFound;
                _response.Resultado = "No existe este id";
                return NotFound(_response);
            }


            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.OK;
            _response.Resultado = _mapper.Map<VillaDTO>(villa);
            return Ok(_response);

        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> crearVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _villaRepo.Obtener(villa => villa.Nombre!.ToLower() == createDTO.Nombre!.ToLower()) != null)
            {
                ModelState.AddModelError("ErrorMessage", "Esta villa ya se encuentra registrada");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Villa modelo = _mapper.Map<Villa>(createDTO);
            modelo.FechaCreacion= DateTime.Now;
            modelo.FechaActualizacion= DateTime.Now;
            await _villaRepo.Crear(modelo);
            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.Created;
            _response.Resultado = modelo;
            return CreatedAtRoute("GetVilla", new { id = modelo.Id }, _response);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> deleteVilla(int id)
        {
            _response.isSuccess = false;


            if (id == 0)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var villa = await _villaRepo.Obtener(v => v.Id == id);
            if (villa == null)
            {

                return NotFound(_response);
            }
            await _villaRepo.Eliminar(villa);
            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.NoContent;
            _response.Resultado = NoContent();
            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActionResult<APIResponse>>> actualizar(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            _response.isSuccess = false;
            if (updateDTO == null || id != updateDTO.Id)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var villa = await _villaRepo.Obtener(v => v.Id == id);
            if (villa == null)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            Villa modelo = _mapper.Map<Villa>(updateDTO);
            await _villaRepo.Actualizar(modelo);
            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.OK;
            _response.Resultado = modelo;
            return  Ok(_response);          
        }
       
        [HttpPatch("{id}")]
        public async Task<ActionResult<APIResponse>> actualizarParcial(int id, JsonPatchDocument<VillaUpdateDTO> pathDTO)
        {
            _response.isSuccess = false;
            if (pathDTO == null || id == 0)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var villa = _villaRepo.Obtener(v => v.Id == id, tracked: false);
            var villaUpdateDTO = _mapper.Map<VillaUpdateDTO>(villa);
            if (villa == null)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            pathDTO.ApplyTo(villaUpdateDTO!, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa modelo = _mapper.Map<Villa>(villaUpdateDTO);
            await _villaRepo.Actualizar(modelo);
            return NoContent();
        }

        private ActionResult<APIResponse> enviarExcepcion(string errors)
        {
            _response.isSuccess = false;
            _response.statusCode = HttpStatusCode.BadRequest;
            _response.Resultado = errors;            
        return BadRequest(_response);

        }
    }


}
