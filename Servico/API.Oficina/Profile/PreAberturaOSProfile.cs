using API.Oficina.ViewModel;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class PreAberturaOSProfile : AutoMapper.Profile
    {
        public PreAberturaOSProfile()
        {
            CreateMap<PreAberturaOSViewModel, PreAberturaOS>();
            CreateMap<PreAberturaOS, PreAberturaOSViewModel>();
        }
    }
}
