using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Modelo.Dominio.ValueObjects.Enums;

namespace Modelo.Dominio.Servicos
{
    public class PerguntaOSServico : IPerguntaOSServico
    {
        private readonly IPerguntaOSRepositorio _repositorio;
        private readonly IPreOrdemServicoServico _preOrdemServicoServico;
        public PerguntaOSServico(IPerguntaOSRepositorio repositorio,IPreOrdemServicoServico preOrdemServicoServico)
        {
            _repositorio = repositorio;
            _preOrdemServicoServico = preOrdemServicoServico;
        }
        public async Task<PerguntaOS> CarregarPerguntaInicial()
        {
            return await _repositorio.CarregarPerguntaInicial();
        }

        public async Task<PerguntaOS> CarregarPerguntaPorId(int id)
        {
            return await _repositorio.CarregarPerguntaPorId(id);
        }

        public async Task<PreAberturaOS> CarregarPreAberturaOS(int id,int? carroId)
        {
            var preAbertura =  await _repositorio.CarregarPreAberturaOS(id);
            if(preAbertura.Tipo == (int)TipoPreAbertura.AbrirOS)
            {
                if (carroId.HasValue)
                    await _preOrdemServicoServico.InserirPreOrdemServico(carroId.Value, preAbertura.Assunto, preAbertura.Descricao);
            }
            return preAbertura;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public async Task<PerguntaOSAlternativa> InserirAlternativa(PerguntaOSAlternativa alternativa)
        {
            return await _repositorio.InserirAlternativa(alternativa);
        }

        public async Task<PerguntaOS> InserirPergunta(PerguntaOS pergunta)
        {
            return await _repositorio.InserirPergunta(pergunta);
        }

        public async Task<PreAberturaOS> InserirPreAbertura(PreAberturaOS preAbertura)
        {
            return await _repositorio.InserirPreAbertura(preAbertura);
        }
    }
}
