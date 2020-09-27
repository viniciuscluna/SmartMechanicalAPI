using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class OrdemServico : EntidadeBase
    {
        public int Status { get; set; }
        public bool Aprovacao { get; set; }
        public string Referencia { get; set; }
        public string ProblemaRelatado { get; set; }
        public string ProblemaDescrito { get; set; }

       
        public DateTime DataAbertura { get; set; }


        public int CarroId { get; set; }

        [ForeignKey("CarroId")]
        public Carro Carro { get; set; }
        public IEnumerable<ServicoOrdemServico> Servicos { get; set; } = new List<ServicoOrdemServico>();

    }
}
