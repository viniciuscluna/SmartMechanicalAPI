using Infra.Data.Contexto;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class OrdemServicoRepositorio : BaseRepositorio<OrdemServico>, IOrdemServicoRepositorio
    {
        private readonly OficinaContext _context;
        public OrdemServicoRepositorio(OficinaContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdemServico>> BuscarPorDocumento(string documento)
        {
            var cliente = await _context.Cliente.Where(x => x.CpfCnpj == documento).Include(x => x.Carros).FirstOrDefaultAsync();

            if (cliente != null)
            {
                var ordensServico = await _context.OrdemServico
                    .Where(x => cliente.Carros.Select(j => j.Id).Contains(x.CarroId))
                     .Include(x => x.Servicos)
                     .ThenInclude(x => x.Servico)
                     .Include(x => x.Carro)
                     .ThenInclude(x => x.Cliente)
                    .ToListAsync();
                return ordensServico;
            }
            else return null;
        }

        public async Task<IEnumerable<OrdemServico>> BuscarPorStatus(string status = null)
        {
            if (status != null)
            {


                List<int> statusUsar = new List<int>();

                status.Split(",").ToList().ForEach(x => statusUsar.Add(int.Parse(x)));



                return await _context.OrdemServico.Where(x => statusUsar.Contains(x.Status))
                     .Include(x => x.Servicos)
                     .ThenInclude(x => x.Servico)
                     .Include(x => x.Carro)
                     .ThenInclude(x => x.Cliente)
                     .ToListAsync();
            }
            else
            {
                return null;

            }
        }

        public async Task<IEnumerable<OrdemServico>> ListarComInclude()
        {
          
          return await _context.OrdemServico
           .Include(x => x.Servicos)
           .ThenInclude(x => x.Servico)
           .Include(x => x.Carro)
           .ThenInclude(x => x.Cliente)
           .ToListAsync();

        }

        public async Task<OrdemServico> ObterComInclude(string referencia)
        {

          return await _context.OrdemServico
                 .Include(x => x.Servicos)
                 .ThenInclude(x => x.Servico)
                 .Include(x => x.Carro)
                 .ThenInclude(x => x.Cliente)
                 .FirstOrDefaultAsync(x => x.Referencia == referencia);
        }
    }
}
