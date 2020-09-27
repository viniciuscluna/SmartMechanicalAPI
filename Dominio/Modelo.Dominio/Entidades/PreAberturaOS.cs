using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class PreAberturaOS : EntidadeBase
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }

        public int Tipo { get; set; }
    }
}
