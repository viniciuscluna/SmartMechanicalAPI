using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class ClienteServico : BaseServico<Cliente, IClienteRepositorio>, IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await _repositorio.GetByEmail(email);
        }

        public async Task<Cliente> GetWithIncludeAsync(string cpfCnpj)
        {
            return await _repositorio.GetWithIncludeAsync(cpfCnpj);
        }
    }
}
