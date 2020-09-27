using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class ClienteViewModel : EntidadeBaseViewModel
    {

        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
        public string PerfilSistema { get; set; }

        public int OficinaId { get; set; }

      
        public OficinaViewModel Oficina { get; set; }

        public IEnumerable<CarroViewModel> Carros { get; set; } = new List<CarroViewModel>();
    }
}
