using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class PerguntaOSAlternativaViewModel : EntidadeBaseViewModel
    {
        public string Alternativa { get; set; }

        public int PerguntaOSId { get; set; }

        public bool AlternativaFinal { get; set; }

        public int? PreAberturaOSId { get; set; }

        public int? ProximaPerguntaOSId { get; set; }

        public PerguntaOSViewModel ProximaPerguntaOS { get; set; }

        public PreAberturaOSViewModel PreAberturaOS { get; set; }

        public PerguntaOSViewModel PerguntaOS { get; set; }
    }
}
