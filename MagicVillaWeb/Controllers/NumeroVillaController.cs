using AutoMapper;
using MagicVilla_Utilidad.DTO;
using MagicVillaWeb.Models;
using MagicVillaWeb.Models.ViewModel;
using MagicVillaWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;

namespace MagicVillaWeb.Controllers
{
    public class NumeroVillaController : Controller
    {

        private readonly INumeroVillaService _numeroVillaService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public NumeroVillaController(INumeroVillaService numeroVillaService,
            IVillaService villaService,
            IMapper mapper)
        {            
            _mapper = mapper;
            _villaService = villaService;
            _numeroVillaService = numeroVillaService;
        }
        public async Task<IActionResult> IndexNumeroVilla()
        {
            List<NumeroVillaDTO> numeroVillaList = new();
            var response = await _numeroVillaService.obtenerTodos<APIResponse>();
            if (response != null && response.isSuccess)
            {
               numeroVillaList = JsonConvert.DeserializeObject<List<NumeroVillaDTO>>(Convert.ToString(response.Resultado));                
            }
            return View(numeroVillaList);
        }

        public async Task<IActionResult> CrearNumeroVilla()
        {
            NumeroVillaViewModel numeroVillaVM = new();
            numeroVillaVM.villaList = await this.obtenerOpciones();            
            return View(numeroVillaVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearNumeroVilla(NumeroVillaViewModel modelo)        
        {

            if (ModelState.IsValid)
            {
                var response = await _numeroVillaService.Crear<APIResponse>(modelo.NumeroVilla);
                if (response!=null && response.isSuccess)
                {
                    TempData["exitoso"] = "Numero Villa creada exitosamente";
                    return RedirectToAction(nameof(IndexNumeroVilla));
                    
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "Error en el registro");
                }
                
            }
            var res = await _villaService.obtenerTodos<APIResponse>();
            if (res != null && res.isSuccess)
            {
               modelo.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(res.Resultado)).Select(v => new SelectListItem { Text = v.Nombre, Value = v.Id.ToString() });
            }
            return View(modelo);
        }



        [HttpGet]
        public async Task<IActionResult> ActualizarNumeroVilla(int villaNo)
        {
            NumeroVillaUpdateViewModel numeroVillaVM = new();
            var response = await _numeroVillaService.obtener<APIResponse>(villaNo);
            if (response!=null && response.isSuccess)
            {
                NumeroVillaDTO modelo = JsonConvert.DeserializeObject<NumeroVillaDTO>(Convert.ToString(response.Resultado));
                numeroVillaVM.NumeroVilla = _mapper.Map<NumeroVillaUpdateDTO>(modelo);
                numeroVillaVM.villaList = await this.obtenerOpciones(); ;
                return View(numeroVillaVM);
            }
                        
            return NotFound();
            
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarNumeroVilla(NumeroVillaUpdateViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _numeroVillaService.Actualizar<APIResponse>(modelo.NumeroVilla);
                if (response != null && response.isSuccess)
                {
                    TempData["exitoso"] = "Numero Villa actualizada exitosamente";
                    return RedirectToAction(nameof(IndexNumeroVilla));
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "Error en el registro");
                }

            }
            modelo.villaList= await this.obtenerOpciones();            
            return View(modelo);
        }




        [HttpGet]
        public async Task<IActionResult> BorrarNumeroVilla(int villaNo)
        {
            NumeroVillaDeleteViewModel numeroVillaVM = new();
            var response = await _numeroVillaService.obtener<APIResponse>(villaNo);
            if (response != null && response.isSuccess)
            {
                NumeroVillaDTO modelo = JsonConvert.DeserializeObject<NumeroVillaDTO>(Convert.ToString(response.Resultado));
                numeroVillaVM.NumeroVilla = modelo;
                numeroVillaVM.villaList = await this.obtenerOpciones(); ;
                return View(numeroVillaVM);
            }

            return NotFound();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarNumeroVilla(NumeroVillaDeleteViewModel model)
        {
            var response = await _numeroVillaService.Remover<APIResponse>(model.NumeroVilla.VillaNo);
            if (response!= null && response.isSuccess)
            {
                TempData["exitoso"] = "Numero Villa eliminada exitosamente";
                return RedirectToAction(nameof(IndexNumeroVilla));
            }
            TempData["error"] = "Error al eliminar el numero de villa";
            return View(model);

        }




        private async Task<IEnumerable<SelectListItem>> obtenerOpciones()
        {
            IEnumerable<SelectListItem> items = new List<SelectListItem>();
            var response = await _villaService.obtenerTodos<APIResponse>();
            
            if (response != null && response.isSuccess)
            {
                items = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Resultado)).Select(v => new SelectListItem { Text = v.Nombre, Value = v.Id.ToString() });
            }
            return items;
        }

    }
}
