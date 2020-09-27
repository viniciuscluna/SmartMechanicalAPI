using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class Mecanico : EntidadeBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public int OficinaId { get; set; }

        [ForeignKey("OficinaId")]
        public Oficina  Oficina { get; set; }
    }
}
