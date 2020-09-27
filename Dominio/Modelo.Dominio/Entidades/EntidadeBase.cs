using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public class EntidadeBase
    {
        [Key]
        public int Id { get; set; }
    }
}
