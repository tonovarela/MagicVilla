

using MagicVilla_Utilidad.DTO;

namespace MagicVilla_API.Datos
{
    public class VillaStore
    {

        public static List<VillaUpdateDTO> villaList = new List<VillaUpdateDTO>
        {
            new VillaUpdateDTO(){ Id=1,Nombre="Varela1",Ocupantes=1,MetrosCuadrados=3},
            new VillaUpdateDTO(){ Id=2,Nombre="Varela2",Ocupantes=2,MetrosCuadrados=3},
            new VillaUpdateDTO(){ Id=3,Nombre="Varela3",Ocupantes=2,MetrosCuadrados=3},
            new VillaUpdateDTO(){ Id=4,Nombre="Varela4",Ocupantes=2,MetrosCuadrados=3}
        };
    }
}
