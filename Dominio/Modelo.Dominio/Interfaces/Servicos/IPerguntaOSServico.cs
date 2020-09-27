using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IPerguntaOSServico : IDisposable
    {
        Task<PerguntaOS> CarregarPerguntaInicial();
        Task<PerguntaOS> CarregarPerguntaPorId(int id);
        Task<PreAberturaOS> CarregarPreAberturaOS(int id,int? carroId);
        Task<PerguntaOS> InserirPergunta(PerguntaOS pergunta);
        Task<PerguntaOSAlternativa> InserirAlternativa(PerguntaOSAlternativa alternativa);
        Task<PreAberturaOS> InserirPreAbertura(PreAberturaOS preAbertura);
    }
}
