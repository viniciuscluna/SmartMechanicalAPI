using API.Oficina.ViewModel;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class PerguntaOSAlternativaProfile : AutoMapper.Profile
    {
        public PerguntaOSAlternativaProfile()
        {
            CreateMap<PerguntaOSAlternativaViewModel, PerguntaOSAlternativa>();
            CreateMap<PerguntaOSAlternativa, PerguntaOSAlternativaViewModel>();
        }
    }
}
