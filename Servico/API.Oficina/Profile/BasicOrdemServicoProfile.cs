using API.Oficina.ViewModel;
using Modelo.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class BasicOrdemServicoProfile : AutoMapper.Profile
    {
        public BasicOrdemServicoProfile()
        {
            CreateMap<BasicOrdemServicoViewModel, BasicOrdemServico>();
            CreateMap<BasicOrdemServico, BasicOrdemServicoViewModel>();
        }
    }
}
