using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Servicos
{
    public class BaseServico<T,TR> :  IBaseServico<T>, IDisposable
        where T : EntidadeBase
        where TR : IBaseRepositorio<T>
    {

        private readonly TR _repositorio;

        public BaseServico(TR repositorio)
        {
            _repositorio = repositorio;
        }

        public  async Task<T> AdicionarAsync(T entidade)
        {
            return await _repositorio.AdicionarAsync(entidade);
        }

        public async  Task<T> AtualizarAsync(T entidade)
        {
            return await _repositorio.AtualizarAsync(entidade);
        }

   

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> filtro = null)
        {
            return await _repositorio.ListarAsync(filtro);
        }

        public async Task<T> ObterAsync(int id)
        {
            return await _repositorio.ObterAsync(id);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            return await _repositorio.RemoverAsync(id);
        }

        public async Task<T> ConsultarAsync(Expression<Func<T, bool>> filtro)
        {
            return await _repositorio.ConsultarAsync(filtro);
        }

        public async Task<bool> ExisteFiltroAsync(Expression<Func<T, bool>> filtro)
        {
            return await _repositorio.ExisteFiltroAsync(filtro);
        }
        public void Dispose()
        {
            _repositorio.Dispose();
        }

      
    }
}
