using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class ServicoOrdemServico : EntidadeBase
    {
        public int ServicoId { get; set; }

        [ForeignKey("ServicoId")]
        public Servico Servico { get; set; }

        [ForeignKey("OrdemServicoId")]
        public int OrdemServicoId { get; set; }

        public OrdemServico OrdemServico { get; set; }

        public string DescricaoServico { get; set; }

        public double ValorServico { get; set; }
    }
}
