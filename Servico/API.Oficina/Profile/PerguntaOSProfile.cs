using API.Oficina.ViewModel;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class PerguntaOSProfile : AutoMapper.Profile
    {
        public PerguntaOSProfile()
        {
            CreateMap<PerguntaOSViewModel, PerguntaOS>();
            CreateMap<PerguntaOS, PerguntaOSViewModel>();
        }
    }
}
