using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class PerguntaOSAlternativa : EntidadeBase
    {
        public string Alternativa { get; set; }

        public int PerguntaOSId { get; set; }

        public bool AlternativaFinal { get; set; }

        public int? PreAberturaOSId { get; set; }

        public int? ProximaPerguntaOSId { get; set; }
        
        [ForeignKey("ProximaPerguntaOSId")]
        public PerguntaOS ProximaPerguntaOS { get; set; }

        [ForeignKey("PreAberturaOSId")]
        public PreAberturaOS PreAberturaOS { get; set; }

        [ForeignKey("PerguntaOSId")]
        public PerguntaOS PerguntaOS { get; set; }
    }
}
