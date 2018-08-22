using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SMSSender.Persistence.Repositories.Base
{
    public interface ICrudRepository<TEntityType>
        where TEntityType : class
    {
        IQueryable<TEntityType> Get();

        Task<TEntityType> Get(long id, CancellationToken cancellationToken);

        Task<TEntityType> Get<TProperty>(long id, CancellationToken cancellationToken, params Expression<Func<TEntityType, TProperty>>[] include);

        TEntityType Add(TEntityType entityType);

        void Delete(TEntityType entityType);

        TEntityType Create();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}