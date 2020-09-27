using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class OrdemServicoViewModel : EntidadeBaseViewModel
    {
        public int Status { get; set; }
        public bool Aprovacao { get; set; }
        public string Referencia { get; set; }
        public string ProblemaRelatado { get; set; }
        public string ProblemaDescrito { get; set; }

        public DateTime DataAbertura { get; set; }

        public int CarroId { get; set; }

        
        public CarroViewModel Carro { get; set; }
        public IEnumerable<ServicoOrdemServicoViewModel> Servicos { get; set; } = new List<ServicoOrdemServicoViewModel>();

    }
}
