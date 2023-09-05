using MagicVilla_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla_API.Model.DTO
{
    public class LoginResponseDTO
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
