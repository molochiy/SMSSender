using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Persistence.Entities;

namespace SMSSender.Persistence.Repositories.Base
{
    public abstract class CrudRepositoryBase<TEntity> : ICrudRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected IDbProvider<ISmsSenderDb> DbProvider { get; }

        protected ISmsSenderDb Db => DbProvider.Get();

        protected CrudRepositoryBase(IDbProvider<ISmsSenderDb> dbProvider)
        {
            DbProvider = dbProvider;
        }

        public virtual IQueryable<TEntity> Get()
        {
            return GetDbSet();
        }

        public async Task<TEntity> Get(long id, CancellationToken cancellationToken)
        {
            return await GetSingleById(id, cancellationToken, Get()).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> Get<TProperty>(long id, CancellationToken cancellationToken, params Expression<Func<TEntity, TProperty>>[] includes)
        {
            IQueryable<TEntity> dbSet = Get();

            foreach (Expression<Func<TEntity, TProperty>> include in includes)
            {
                dbSet.Include(include);
            }

            return await GetSingleById(id, cancellationToken, dbSet).ConfigureAwait(false);
        }

        public virtual TEntity Add(TEntity entityType)
        {
            return GetDbSet().Add(entityType);
        }

        public virtual void Delete(TEntity entityType)
        {
            GetDbSet().Remove(entityType);
        }

        public virtual TEntity Create()
        {
            return GetDbSet().Create();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Db.DbContext.SaveChangesAsync(cancellationToken);
        }

        protected abstract DbSet<TEntity> GetDbSet();

        private static Task<TEntity> GetSingleById(long id, CancellationToken cancellationToken, IQueryable<TEntity> dbSet)
        {
            return dbSet.SingleAsync(x => x.Id == id, cancellationToken);
        }
    }
}