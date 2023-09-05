using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Utilidad.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }
       [Required]
        public string? ImagenURL { get; set; }
        public string? Amenidad { get; set; }
       [Required]
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }

        
    }
}
