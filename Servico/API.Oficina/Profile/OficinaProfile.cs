using API.Oficina.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Dominio;
namespace API.Oficina.Profile
{
    public class OficinaProfile : AutoMapper.Profile
    {
        public OficinaProfile()
        {
            CreateMap<OficinaViewModel, Modelo.Dominio.Entidades.Oficina>();
            CreateMap<Modelo.Dominio.Entidades.Oficina, OficinaViewModel>();
        }
    }
}
