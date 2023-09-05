using MagicVilla_Utilidad.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVillaWeb.Models.ViewModel
{
    public class NumeroVillaViewModel
    {

        public NumeroVillaViewModel()
        {
            NumeroVilla= new NumeroVillaCreateDTO();
            
        }
        public NumeroVillaCreateDTO  NumeroVilla { get; set; }
        public IEnumerable<SelectListItem> villaList { get; set; }
    }
}
