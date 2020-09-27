using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class PreAberturaOSViewModel : EntidadeBaseViewModel
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
    }
}
