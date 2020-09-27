using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class PreOrdemServicoViewModel : EntidadeBaseViewModel
    {
        public int CarroId { get; set; }

        
        public CarroViewModel Carro { get; set; }
        public string Referencia { get; set; }
        public string ProblemaRelatado { get; set; }
        public string ProblemaDescrito { get; set; }

        public DateTime DataAbertura { get; set; }
    }
}
