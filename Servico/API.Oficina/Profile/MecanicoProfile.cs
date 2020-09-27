using API.Oficina.ViewModel;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina.Profile
{
    public class MecanicoProfile : AutoMapper.Profile
    {
        public MecanicoProfile()
        {
            CreateMap<MecanicoViewModel, Mecanico>();
            CreateMap<Mecanico, MecanicoViewModel>();
        }
    }
}
