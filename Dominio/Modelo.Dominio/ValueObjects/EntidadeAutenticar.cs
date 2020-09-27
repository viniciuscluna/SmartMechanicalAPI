using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.ValueObjects
{
    public class EntidadeAutenticar
    {
        public string Role { get; set; }

        public bool Autenticado { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Documento { get; set; }
    }
}
