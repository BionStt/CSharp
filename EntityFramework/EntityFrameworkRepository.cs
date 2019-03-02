using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples
{
	public class EntityFrameworkRepository<TEntity>
	{
		private readonly DbContext _context;

		protected EntityFrameworkRepository(DbContext context)
		{
			_context = context;
			_context.Configuration.AutoDetectChangesEnabled = false;
			_context.Configuration.LazyLoadingEnabled = false;
			_context.Configuration.ProxyCreationEnabled = false;
		}

		public void Add(TEntity entity)
		{
			AddOrUpdate(entity);
		}

		public void AddOrUpdate(TEntity entity)
		{
			_context.Set<TEntity>().AddOrUpdate(entity);
		}

		public bool Any(Expression<Func<TEntity, bool>> filter = null)
		{
			return Queryable(filter).Any();
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
		{
			return Queryable(filter).AnyAsync();
		}

		public long Count(Expression<Func<TEntity, bool>> filter = null)
		{
			return Queryable(filter).LongCount();
		}

		public Task<long> CountAsync(Expression<Func<TEntity, bool>> filter = null)
		{
			return Queryable(filter).LongCountAsync();
		}

		public void Delete(object id)
		{
			Delete(Select(id));
		}

		public void Delete(TEntity entity)
		{
			if (entity == null) { return; }
			Attach(entity);
			_context.Set<TEntity>().Remove(entity);
		}

		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Queryable(filter, includeProperties).FirstOrDefault();
		}

		public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return await Queryable(filter, includeProperties).FirstOrDefaultAsync();
		}

		public TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Queryable(filter, includeProperties).LastOrDefault();
		}

		public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Queryable(filter, includeProperties).ToList();
		}

		public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return await Queryable(filter, includeProperties).ToListAsync();
		}

		public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> queryable = _context.Set<TEntity>();

			if (filter != null)
			{ queryable = queryable.Where(filter); }

			includeProperties?.ToList().ForEach(property => queryable = queryable.Include(property));

			return queryable;
		}

		public TEntity Select(object id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public Task<TEntity> SelectAsync(object id)
		{
			return _context.Set<TEntity>().FindAsync(id);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Queryable(filter, includeProperties).SingleOrDefault();
		}

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return await Queryable(filter, includeProperties).SingleOrDefaultAsync();
		}

		public void Update(TEntity entity)
		{
			AddOrUpdate(entity);
		}

		private void Attach(TEntity entity)
		{
			if (_context.Entry(entity).State == EntityState.Detached)
			{
				_context.Set<TEntity>().Attach(entity);
			}
		}
	}
}
