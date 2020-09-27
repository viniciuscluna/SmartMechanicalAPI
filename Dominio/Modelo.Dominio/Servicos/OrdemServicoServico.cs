using Infra.Comum.Email.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using Modelo.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class OrdemServicoServico : BaseServico<OrdemServico, IOrdemServicoRepositorio>, IOrdemServicoServico
    {
        private readonly IOrdemServicoRepositorio _repositorio;
        private readonly IClienteServico _clienteServico;
        private readonly IEmailServico _emailServico;
        private readonly ICarroServico _carroServico;

        public OrdemServicoServico(
            IOrdemServicoRepositorio repositorio,
            IClienteServico clienteServico,
            IEmailServico emailServico,
            ICarroServico carroServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _clienteServico = clienteServico;
            _emailServico = emailServico;
            _carroServico = carroServico;
        }

        public async Task<OrdemServico> AtualizarStatus(BasicOrdemServico basicOrdem, string referencia)
        {
            var ordemServico = await _repositorio.ConsultarAsync(x => x.Referencia == referencia);
            if (ordemServico != null)
            {
                ordemServico.Aprovacao = basicOrdem.Aprovacao;
                ordemServico.Status = basicOrdem.Status;
                ordemServico = await _repositorio.AtualizarAsync(ordemServico);

                return ordemServico;

            }
            else return null;
        }

        public async Task<IEnumerable<OrdemServico>> BuscarPorDocumento(string documento)
        {
            return await _repositorio.BuscarPorDocumento(documento);
        }

        public async Task<IEnumerable<OrdemServico>> BuscarPorStatus(string status = null)
        {
            return await _repositorio.BuscarPorStatus(status);
        }

        public async Task<OrdemServico> InserirOrdemServico(OrdemServico ordemServico)
        {
            var rnd = new Random();
            string numeroAleatorio = rnd.Next(10000).ToString();

            while (await _repositorio.ExisteFiltroAsync(x => x.Referencia == numeroAleatorio))
            {
                numeroAleatorio = rnd.Next(10000).ToString();
            }
            ordemServico.Referencia = numeroAleatorio;
            ordemServico.Status = 1;
            ordemServico.DataAbertura = DateTime.Now;

            if (ordemServico.CarroId == 0)
            {
                var clienteExiste = await _clienteServico.ConsultarAsync(x => x.Email == ordemServico.Carro.Cliente.Email);
                if (clienteExiste != null)
                {
                    ordemServico.Carro.Cliente = clienteExiste;
                }
                else
                {
                    ordemServico.Carro.Cliente.OficinaId = 1;
                    ordemServico.Carro.Cliente.Senha = rnd.Next(1000).ToString();
                }
            }
            else
            {
                ordemServico.Carro = null;
            }

            ordemServico = await _repositorio.AdicionarAsync(ordemServico);


            StringBuilder sb = new StringBuilder(await _emailServico.HTMLEmailAbertura());
           
            sb.Replace("{Assunto}", $"OS: {ordemServico.Referencia} - {ordemServico.ProblemaRelatado}");
            sb.Replace("{Descricao}", ordemServico.ProblemaDescrito);

            if (ordemServico.Carro == null)
            {
                ordemServico.Carro = await _carroServico.ObterComInclude(ordemServico.CarroId);
            }
            sb.Replace("{Cliente}", ordemServico.Carro.Cliente.Nome);
            _emailServico.SendEmailAsync(ordemServico.Carro.Cliente.Email, "Abertura de OS", sb.ToString());


            return ordemServico;

        }

        public async Task<IEnumerable<OrdemServico>> ListarComInclude()
        {
            return await _repositorio.ListarComInclude();
        }

        public async Task<OrdemServico> ObterComInclude(string referencia)
        {
            return await _repositorio.ObterComInclude(referencia);
        }
    }
}
