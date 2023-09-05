using AutoMapper;
using MagicVilla_Utilidad.DTO;

using MagicVillaWeb.Models;
using MagicVillaWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVillaWeb.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> villaList = new();
            var response = await _villaService.obtenerTodos<APIResponse>();
            if (response != null && response.isSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Resultado));
            }
            return View(villaList);
        }

        public IActionResult CrearVilla()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crearVilla(VillaCreateDTO villa)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Crear<APIResponse>(villa);
                if (response != null && response.isSuccess)
                {
                    TempData["exitoso"] = "Villa creada exitosamente";
                    return RedirectToAction("IndexVilla");

                }
            }
            return View(villa);

        }

        public async Task<IActionResult> ActualizarVilla(int villaId)
        {
            var response = await _villaService.obtener<APIResponse>(villaId);
            if (response != null && response.isSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Resultado));
                return View(_mapper.Map<VillaDTO, VillaUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Actualizar<APIResponse>(model);

                if (response !=null && response.isSuccess)
                {
                    TempData["exitoso"] = "Villa actualizada exitosamente";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Ocurrio un error al actualizar la villa";

            return View(model);
        }


        public async Task<IActionResult> RemoverVilla(int villaId)
        {
            var response = await _villaService.obtener<APIResponse>(villaId);
            if (response != null && response.isSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Resultado));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverVilla(VillaDTO model)
        {        
                var response = await _villaService.Remover<APIResponse>(model.Id);
                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }           
            return View(model);
        }
    }



}
