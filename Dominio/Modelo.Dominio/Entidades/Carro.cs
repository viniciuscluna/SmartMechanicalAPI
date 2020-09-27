using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class Carro : EntidadeBase
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

       


        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}
