using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IPreOrdemServicoServico : IBaseServico<PreOrdemServico>
    {
        Task<PreOrdemServico> InserirPreOrdemServico(int carroId, string problemaRelatado, string problemaDescrito);
        Task<IEnumerable<PreOrdemServico>> ListarComIncludeAsync();
    }
}
