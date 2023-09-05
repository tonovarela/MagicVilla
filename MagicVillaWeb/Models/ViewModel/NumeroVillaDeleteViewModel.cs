using MagicVilla_Utilidad.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVillaWeb.Models.ViewModel
{
    public class NumeroVillaDeleteViewModel
    {

        public NumeroVillaDeleteViewModel()
        {
            NumeroVilla = new NumeroVillaDTO();
            
        }
        public NumeroVillaDTO NumeroVilla { get; set; }
        public IEnumerable<SelectListItem> villaList { get; set; }
    }
}
