using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class PerguntaOSViewModel : EntidadeBaseViewModel
    {
        public string Pergunta { get; set; }

        public bool PerguntaInicial { get; set; }


        public IEnumerable<PerguntaOSAlternativaViewModel> Alternativas { get; set; }
    }
}
