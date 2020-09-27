using Modelo.Dominio.Entidades;
using Modelo.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IOrdemServicoServico : IBaseServico<OrdemServico>
    {
        Task<IEnumerable<OrdemServico>> BuscarPorDocumento(string documento);
        Task<OrdemServico> AtualizarStatus(BasicOrdemServico basicOrdem, string referencia);
        Task<IEnumerable<OrdemServico>> BuscarPorStatus(string status = null);
        Task<IEnumerable<OrdemServico>> ListarComInclude();
        Task<OrdemServico> ObterComInclude(string referencia);

        Task<OrdemServico> InserirOrdemServico(OrdemServico ordemServico);
    }
}
