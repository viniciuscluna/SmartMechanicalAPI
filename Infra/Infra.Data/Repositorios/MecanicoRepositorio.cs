using Infra.Data.Contexto;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class MecanicoRepositorio : BaseRepositorio<Mecanico>,IMecanicoRepositorio
    {
       
        public MecanicoRepositorio(OficinaContext context)
            :base(context)
        {
           
        }
    }
}
