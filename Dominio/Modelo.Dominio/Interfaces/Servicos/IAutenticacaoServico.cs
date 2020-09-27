using Modelo.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IAutenticacaoServico : IDisposable
    {
        Task<EntidadeAutenticar> AutenticarUsuario(EntidadeAutenticar entidade);
    }
}
