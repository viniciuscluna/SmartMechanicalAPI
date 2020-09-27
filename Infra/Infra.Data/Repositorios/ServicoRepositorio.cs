using Infra.Data.Contexto;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class ServicoRepositorio : BaseRepositorio<Servico>, IServicoRepositorio
    {

        public ServicoRepositorio(OficinaContext context)
            : base(context)
        {
      
        }
    }
}
