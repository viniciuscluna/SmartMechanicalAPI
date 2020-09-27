using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Repositorios
{
    public  interface IOrdemServicoRepositorio: IBaseRepositorio<OrdemServico>
    {
        Task<IEnumerable<OrdemServico>> BuscarPorDocumento(string documento);
        Task<IEnumerable<OrdemServico>> BuscarPorStatus(string status = null);

        Task<IEnumerable<OrdemServico>> ListarComInclude();
        Task<OrdemServico> ObterComInclude(string referencia);
    }
}
