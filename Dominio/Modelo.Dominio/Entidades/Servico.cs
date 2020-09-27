using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class Servico : EntidadeBase
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
