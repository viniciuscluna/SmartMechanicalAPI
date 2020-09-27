using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class PreOrdemServicoServico : BaseServico<PreOrdemServico, IPreOrdemServicoRepositorio>, IPreOrdemServicoServico
    {
        private readonly IPreOrdemServicoRepositorio _repositorio;
        private readonly IOrdemServicoServico _ordemServicoServico;
        public PreOrdemServicoServico(IPreOrdemServicoRepositorio repositorio,IOrdemServicoServico ordemServicoServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _ordemServicoServico = ordemServicoServico;
        }

        public async Task<IEnumerable<PreOrdemServico>> ListarComIncludeAsync()
        {
            return await _repositorio.ListarComIncludeAsync();
        }
        public async Task<PreOrdemServico> InserirPreOrdemServico(int carroId,string problemaRelatado,string problemaDescrito)
        {
            PreOrdemServico preOrdemServico = new PreOrdemServico();
            preOrdemServico.CarroId = carroId;
            preOrdemServico.ProblemaDescrito = problemaDescrito;
            preOrdemServico.ProblemaRelatado = problemaRelatado;

            var rnd = new Random();
            string numeroAleatorio = rnd.Next(10000).ToString();

            while (await _repositorio.ExisteFiltroAsync(x => x.Referencia == numeroAleatorio))
            {
                numeroAleatorio = rnd.Next(10000).ToString();
            }
            preOrdemServico.Referencia = numeroAleatorio;
            preOrdemServico.DataAbertura = DateTime.Now;
            await _repositorio.AdicionarAsync(preOrdemServico);

            return preOrdemServico;
        }
    }
}
