using System.Data.Entity;
using SMSSender.Persistence.Entities;
using SMSSender.Persistence.Repositories.Base;

namespace SMSSender.Persistence.Repositories
{
    public class UserOrdersRepository : CrudRepositoryBase<UserOrdersEntity>, IUserOrdersRepository
    {
        public UserOrdersRepository(IDbProvider<ISmsSenderDb> dbProvider) : base(dbProvider)
        {
        }

        protected override DbSet<UserOrdersEntity> GetDbSet()
        {
            return this.Db.UsersOrders;
        }
    }
}