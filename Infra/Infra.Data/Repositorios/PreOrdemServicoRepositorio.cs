using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositorios
{
    public class PreOrdemServicoRepositorio : BaseRepositorio<PreOrdemServico>, IPreOrdemServicoRepositorio
    {
        private readonly OficinaContext _context;
        public PreOrdemServicoRepositorio(OficinaContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PreOrdemServico>> ListarComIncludeAsync()
        {
            return await _context.PreOrdemServico.Include(i => i.Carro).ThenInclude(i => i.Cliente).ToListAsync();
        }
    }
}
