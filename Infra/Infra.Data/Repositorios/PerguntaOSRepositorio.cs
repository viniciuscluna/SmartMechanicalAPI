using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositorios
{
    public class PerguntaOSRepositorio : IPerguntaOSRepositorio
    {
        private readonly OficinaContext _context;
        public PerguntaOSRepositorio(OficinaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PerguntaOSAlternativa>> CarregarAlternativasPergunta(int perguntaId)
        {
            var result = await _context.PerguntaOSAlternativa.Where(f => f.PerguntaOSId == perguntaId).ToListAsync();
            return result;
        }

        public async Task<PerguntaOS> CarregarPerguntaInicial()
        {
            var result = await _context.PerguntaOS.Where(f => f.PerguntaInicial)
                .FirstOrDefaultAsync();

            if (result != null)
                result.Alternativas = await CarregarAlternativasPergunta(result.Id);

            return result;
        }

        public async Task<PerguntaOS> CarregarPerguntaPorId(int id)
        {
            var result = await _context.PerguntaOS.Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            if (result != null)
                result.Alternativas = await CarregarAlternativasPergunta(result.Id);

            return result;
        }

        public async Task<PreAberturaOS> CarregarPreAberturaOS(int id)
        {
            var result = await _context.PreAberturaOS.Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<PerguntaOSAlternativa> InserirAlternativa(PerguntaOSAlternativa alternativa)
        {
            await _context.PerguntaOSAlternativa.AddAsync(alternativa);
            await _context.SaveChangesAsync();
            return alternativa;
        }

        public async Task<PerguntaOS> InserirPergunta(PerguntaOS pergunta)
        {
            await _context.PerguntaOS.AddAsync(pergunta);
            await _context.SaveChangesAsync();
            foreach (var alternativa in pergunta.Alternativas)
            {
                alternativa.PerguntaOSId = pergunta.Id;
                await _context.PerguntaOSAlternativa.AddAsync(alternativa);
                await _context.SaveChangesAsync();
            }

            return pergunta;
        }

        public async Task<PreAberturaOS> InserirPreAbertura(PreAberturaOS preAbertura)
        {
            await _context.PreAberturaOS.AddAsync(preAbertura);
            await _context.SaveChangesAsync();
            return preAbertura;
        }
    }
}
