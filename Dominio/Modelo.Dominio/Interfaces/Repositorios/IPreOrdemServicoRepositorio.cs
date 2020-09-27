﻿using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Repositorios
{
    public interface IPreOrdemServicoRepositorio : IBaseRepositorio<PreOrdemServico>
    {
        Task<IEnumerable<PreOrdemServico>> ListarComIncludeAsync();
    }
}
