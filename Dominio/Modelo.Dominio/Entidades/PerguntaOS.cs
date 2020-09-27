using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class PerguntaOS : EntidadeBase
    {
        public string  Pergunta { get; set; }
        public bool PerguntaInicial { get; set; }

        [NotMapped]
        public IEnumerable<PerguntaOSAlternativa> Alternativas { get; set; }
    }
}
