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
    public class CarroRepositorio : BaseRepositorio<Carro>, ICarroRepositorio
    {
        private readonly OficinaContext _context;
        public CarroRepositorio(OficinaContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carro>> ConsultarCarrosPorEmail(string email)
        {
            return await _context.Carro.Where(f => f.Cliente.Email == email).ToListAsync();
        }

        public async Task<IEnumerable<Carro>> ConsultarPorPlacaAsync(string placa)
        {
            return await _context.Carro.Where(x => placa == null || x.Placa.Contains(placa)).ToListAsync();
        }

        public async Task<Carro> ObterComInclude(int id)
        {
            return await _context.Carro.Include(i => i.Cliente).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
