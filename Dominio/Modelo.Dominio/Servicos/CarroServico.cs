using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class CarroServico : BaseServico<Carro, ICarroRepositorio>, ICarroServico
    {
        private readonly ICarroRepositorio _repositorio;
        public CarroServico(ICarroRepositorio repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Carro>> ConsultarCarrosPorEmail(string email)
        {
            return await _repositorio.ConsultarCarrosPorEmail(email);
        }

        public async  Task<IEnumerable<Carro>> ConsultarPorPlacaAsync(string placa)
        {
            return await _repositorio.ConsultarPorPlacaAsync(placa);
        }

        public async Task<Carro> ObterComInclude(int id)
        {
            return await _repositorio.ObterComInclude(id);
        }
    }
}
