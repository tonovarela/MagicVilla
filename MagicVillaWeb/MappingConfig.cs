using AutoMapper;
using MagicVilla_Utilidad.DTO;

namespace MagicVillaWeb
{
    public class MappingConfig:Profile 
    {

        public MappingConfig()
        {
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

            CreateMap<NumeroVillaDTO, NumeroVillaCreateDTO>().ReverseMap();
            CreateMap<NumeroVillaDTO,NumeroVillaUpdateDTO>().ReverseMap();


        }
    }
}
