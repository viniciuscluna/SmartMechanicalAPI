using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class MecanicoViewModel : EntidadeBaseViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public int OficinaId { get; set; }

    
        public OficinaViewModel Oficina { get; set; }
    }
}
