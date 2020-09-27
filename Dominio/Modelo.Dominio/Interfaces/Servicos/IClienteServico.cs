using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IBaseServico<Cliente>
    {
        Task<Cliente> GetWithIncludeAsync(string cpfCnpj);
        Task<Cliente> GetByEmail(string email);
    }
}
