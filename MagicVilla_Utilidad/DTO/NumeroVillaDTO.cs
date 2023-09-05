using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicVilla_Utilidad.DTO
{
    public class NumeroVillaDTO
    {
    [Required]
     public int VillaNo { get; set; }   
     [Required]
     public int VillaId { get; set; }

     public string? DetalleEspecial { get; set; }

     public VillaDTO? villa { get; set; }

     
    }
}