using Modelo.Dominio.Interfaces.Servicos;
using Modelo.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMecanicoServico _mecanicoServico;
        public AutenticacaoServico(IClienteServico clienteServico, IMecanicoServico mecanicoServico)
        {
            _clienteServico = clienteServico;
            _mecanicoServico = mecanicoServico;
        }

        public async Task<EntidadeAutenticar> AutenticarUsuario(EntidadeAutenticar entidade)
        {
            var mecanico = await _mecanicoServico.ConsultarAsync(x => x.Login == entidade.Email && x.Senha == entidade.Senha);
            var cliente = await _clienteServico.ConsultarAsync(x => x.Email == entidade.Email && x.Senha == entidade.Senha);

            if (mecanico != null)
            {
                return new EntidadeAutenticar()
                {
                    Autenticado = true,
                    Nome = entidade.Email,
                    Email = entidade.Email,
                    Senha = entidade.Senha,
                    Role = "Mecanico"
                };
            }
            else if (cliente != null)
            {
                return new EntidadeAutenticar()
                {
                    Autenticado = true,
                    Nome = entidade.Email,
                    Email = entidade.Email,
                    Senha = entidade.Senha,
                    Documento = cliente.CpfCnpj,
                    Role = "Cliente"
                };
            }
            else
            {
                return new EntidadeAutenticar()
                {
                    Autenticado = false
                };
            }
        }

        public void Dispose()
        {
            _clienteServico.Dispose();
            _mecanicoServico.Dispose();
        }
    }
}
