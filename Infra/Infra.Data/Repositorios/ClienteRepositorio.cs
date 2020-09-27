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
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        private readonly OficinaContext _context;
        public ClienteRepositorio(OficinaContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await _context.Cliente.Where(f => f.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetWithIncludeAsync(string cpfCnpj)
        {
            var cliente = await _context.Cliente
              .Include(x => x.Carros)
              .Include(x => x.Oficina)
              .Where(x => x.CpfCnpj == cpfCnpj).FirstOrDefaultAsync();
            return cliente;

        }
    }
}
