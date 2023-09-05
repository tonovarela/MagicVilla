using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagicVillaWeb.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }

        public bool  isSuccess { get; set; }

        public object? Resultado { get; set; }

        

    }
}