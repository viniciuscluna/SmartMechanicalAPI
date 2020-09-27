using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.ViewModel
{
    public class CarroViewModel : EntidadeBaseViewModel
    {

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }




        public int ClienteId { get; set; }

        
        public ClienteViewModel Cliente { get; set; }
    }
}
