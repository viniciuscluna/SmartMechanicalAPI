using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class ServicoOrdemServicoViewModel : EntidadeBaseViewModel
    {
        public int ServicoId { get; set; }

      
        public ServicoViewModel Servico { get; set; }

      
        public int OrdemServicoId { get; set; }

        public OrdemServicoViewModel OrdemServico { get; set; }

        public string DescricaoServico { get; set; }

        public double ValorServico { get; set; }
    }
}
