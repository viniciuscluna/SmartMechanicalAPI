using API.Oficina.ViewModel;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class PreOrdemServicoProfile : AutoMapper.Profile
    {
        public PreOrdemServicoProfile()
        {
            CreateMap<PreOrdemServicoViewModel, PreOrdemServico>();
            CreateMap<PreOrdemServico, PreOrdemServicoViewModel>();
        }
    }
}
