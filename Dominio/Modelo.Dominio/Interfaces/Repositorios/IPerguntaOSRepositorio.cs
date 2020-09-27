using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Repositorios
{
    public interface IPerguntaOSRepositorio: IDisposable
    {
        Task<PerguntaOS> CarregarPerguntaInicial();
        Task<PerguntaOS> CarregarPerguntaPorId(int id);
        Task<PreAberturaOS> CarregarPreAberturaOS(int id);

        Task<PerguntaOS> InserirPergunta(PerguntaOS pergunta);
        Task<PerguntaOSAlternativa> InserirAlternativa(PerguntaOSAlternativa alternativa);
        Task<PreAberturaOS> InserirPreAbertura(PreAberturaOS preAbertura);
    }
}
