using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class Cliente : EntidadeBase
    {

        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
        public string PerfilSistema { get; set; }

        public int OficinaId { get; set; }

        [ForeignKey("OficinaId")]
        public Oficina Oficina { get; set; }

        public IEnumerable<Carro> Carros { get; set; } = new List<Carro>();
    }
}
