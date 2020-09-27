using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : EntidadeBase
    {
		private readonly OficinaContext _contexto;
		private readonly DbSet<T> _dbSet;

		public BaseRepositorio(OficinaContext contexto)
		{
			_contexto = contexto;
			_dbSet = _contexto.Set<T>();
		}

		public async Task<T> AdicionarAsync(T entidade)
		{
			_dbSet.Add(entidade);
			await _contexto.SaveChangesAsync();
			return entidade;
		}

		public async Task<T> AtualizarAsync(T entidade)
		{
			_contexto.Entry(entidade).State = EntityState.Modified;
			_dbSet.Update(entidade);
			await _contexto.SaveChangesAsync();
			return entidade;
		}

		public async Task<T> ConsultarAsync(Expression<Func<T, bool>> filtro)
		{
			return await _dbSet.Where(filtro).FirstOrDefaultAsync();
		}

		public void Dispose()
		{
			_contexto.Dispose();
		}

		public async  Task<bool> ExisteAsync(int id)
		{
			return await _dbSet.AnyAsync(f => f.Id == id);
		}

		public async  Task<bool> ExisteFiltroAsync(Expression<Func<T, bool>> filtro)
		{
			return await _dbSet.AnyAsync(filtro);
		}

		public async Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> filtro = null)
		{
			if (filtro != null)
				return await _dbSet.Where(filtro).ToListAsync();
			else return await _dbSet.ToListAsync();
		}

		public async  Task<T> ObterAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async  Task<bool> RemoverAsync(int id)
		{
			var item = await _dbSet.FirstAsync(x => x.Id == id);
			_dbSet.Remove(item);
			await _contexto.SaveChangesAsync();
			return true;
		}
	}
}
