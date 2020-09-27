using Infra.Data.Contexto;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class OficinaRepositorio : BaseRepositorio<Oficina>, IOficinaRepositorio
    {
     
        public OficinaRepositorio(OficinaContext context)
            : base(context)
        {
         
        }
    }
}
