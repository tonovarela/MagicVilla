
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
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;

        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public NumeroVillaController(ILogger<NumeroVillaController> logger,
                                    INumeroVillaRepositorio numeroRepo,
                                    IVillaRepositorio villaRepo,
                                    IMapper mapper)
        {
            _numeroRepo = numeroRepo;
            _villaRepo = villaRepo;
            _logger = logger;
            _mapper = mapper;
            _response = new APIResponse();

        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetNumeroVillas()
        {
            try
            {
                IEnumerable<NumeroVilla> villas = await _numeroRepo.Listar(incluirPropiedades:"villa");
                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDTO>>(villas);
                _response.statusCode = HttpStatusCode.OK;
                _response.isSuccess = true;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                return this.enviarExcepcion(ex.ToString());
            }

        }


        [HttpGet("{id}", Name = "GetNumeroVilla")]
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

            var villa = await _numeroRepo.Obtener(v => v.VillaNo == id,incluirPropiedades:"villa");
            if (villa == null)
            {
                _response.statusCode = HttpStatusCode.NotFound;
                _response.Resultado = "No existe este id";
                return NotFound(_response);
            }


            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.OK;
            _response.Resultado = _mapper.Map<NumeroVillaDTO>(villa);
            return Ok(_response);

        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> crearNumeroVilla([FromBody] NumeroVillaCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (await _numeroRepo.Obtener(villa => villa.VillaNo == createDTO.VillaNo) != null)
            //{
            //    ModelState.AddModelError("ErrorMessage", "Este número de villa no se encuentra registrado");
            //    return BadRequest(ModelState);
            //}
            if (await _villaRepo.Obtener(v=>v.Id==createDTO.VillaId)== null){
                ModelState.AddModelError("ErrorMessage", "Este número de villa no existe");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDTO);
            modelo.FechaCreacion = DateTime.Now;
            modelo.FechaActualizacion = DateTime.Now;
            await _numeroRepo.Crear(modelo);
            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.Created;
            _response.Resultado = modelo;
            return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo }, _response);

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
            var villa = await _numeroRepo.Obtener(v => v.VillaNo == id);
            if (villa == null)
            {

                return NotFound(_response);
            }
            await _numeroRepo.Eliminar(villa);
            _response.isSuccess = true;
            _response.statusCode = HttpStatusCode.NoContent;
            _response.Resultado = NoContent();
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ActionResult<APIResponse>>> actualizar(int id, [FromBody] NumeroVillaUpdateDTO updateDTO)
        {
            _response.isSuccess = false;
            if (updateDTO == null || id != updateDTO.VillaNo)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            if (await _villaRepo.Obtener(v => v.Id == updateDTO.VillaId) == null){
                 ModelState.AddModelError("ClaveForanea", "Este numero de villa no existe");
                return BadRequest(_response);
            }
            var villa = await _numeroRepo.Obtener(v => v.VillaNo== id);
            if (villa == null)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            NumeroVilla modelo = _mapper.Map<NumeroVilla>(updateDTO);            
            await _numeroRepo.Actualizar(modelo);
            _response.isSuccess = true;
            _response.statusCode=HttpStatusCode.OK;
            _response.Resultado = modelo;
            return Ok(_response);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<APIResponse>> actualizarParcial(int id, JsonPatchDocument<NumeroVillaUpdateDTO> pathDTO)
        {
            _response.isSuccess = false;
            if (pathDTO == null || id == 0)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var villa = _numeroRepo.Obtener(v => v.VillaNo == id, tracked: false);
            var villaUpdateDTO = _mapper.Map<NumeroVillaUpdateDTO>(villa);
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

            NumeroVilla modelo = _mapper.Map<NumeroVilla>(villaUpdateDTO);
            await _numeroRepo.Actualizar(modelo);
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
