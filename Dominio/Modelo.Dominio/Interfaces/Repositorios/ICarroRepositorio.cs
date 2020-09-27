using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Repositorios
{
    public interface ICarroRepositorio : IBaseRepositorio<Carro>
    {
       
        Task<IEnumerable<Carro>> ConsultarPorPlacaAsync(string placa);
        Task<IEnumerable<Carro>> ConsultarCarrosPorEmail(string email);

        Task<Carro> ObterComInclude(int id);
       
    }
}
