using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class EntidadeAutenticarViewModel
    {
        public string Role { get; set; }

        public bool Autenticado { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Documento { get; set; }
    }
}
