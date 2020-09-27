using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Interfaces.Servicos
{
    public interface IBaseServico<T> : IDisposable where T : EntidadeBase
    {
        Task<T> ObterAsync(int id);

        Task<T> ConsultarAsync(Expression<Func<T, bool>> filtro);
        Task<T> AdicionarAsync(T entidade);
        Task<bool> RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);

        Task<bool> ExisteFiltroAsync(Expression<Func<T, bool>> filtro);
        Task<T> AtualizarAsync(T entidade);
        Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> filtro = null);
    }
}
