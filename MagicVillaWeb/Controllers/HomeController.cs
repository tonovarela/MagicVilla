using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MagicVillaWeb.Models;
using MagicVillaWeb.Services;
using AutoMapper;
using MagicVilla_Utilidad.DTO;
using Newtonsoft.Json;
using MagicVillaWeb.Services.IServices;
using MagicVillaWeb.Models.ViewModel;

namespace MagicVillaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVillaService _villaService;    
    private readonly INumeroVillaService _numeroVillaService;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger,
                          IVillaService villaService,
                          INumeroVillaService numeroVillaService,
                          IMapper mapper)
    {
        _logger = logger;
        _villaService = villaService;
        _mapper = mapper;
        _numeroVillaService= numeroVillaService;
    }
    public async Task<IActionResult> Index()
    {
        List<VillaDTO> villaList = new();
        var response = await _villaService.obtenerTodos<APIResponse>();
        if (response != null && response.isSuccess)
        {
            villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Resultado));
        }
        return View(villaList);
    }


   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    

}
