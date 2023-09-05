using MagicVilla_Utilidad.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVillaWeb.Models.ViewModel
{
    public class NumeroVillaUpdateViewModel
    {

        public NumeroVillaUpdateViewModel()
        {
            NumeroVilla = new NumeroVillaUpdateDTO();
            
        }
        public NumeroVillaUpdateDTO NumeroVilla { get; set; }
        public IEnumerable<SelectListItem> villaList { get; set; }
    }
}
