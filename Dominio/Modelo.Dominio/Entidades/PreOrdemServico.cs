using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class PreOrdemServico : EntidadeBase
    {
        public int CarroId { get; set; }

        [ForeignKey("CarroId")]
        public Carro Carro { get; set; }
        public string Referencia { get; set; }
        public string ProblemaRelatado { get; set; }
        public string ProblemaDescrito { get; set; }

        public DateTime DataAbertura { get; set; }
    }
}
