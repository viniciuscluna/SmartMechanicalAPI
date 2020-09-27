using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Servicos
{
    public class ServicoServico : BaseServico<Servico,IServicoRepositorio> , IServicoServico
    {
        
        public ServicoServico(IServicoRepositorio repositorio)
            : base (repositorio)
        {
           
        }
    }
}
