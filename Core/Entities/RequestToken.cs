using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RequestToken
    {
        public Boolean Respuesta { get; set; }
        public string Token { get; set; } = null!;
    }
}
