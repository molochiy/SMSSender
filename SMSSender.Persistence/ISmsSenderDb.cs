using System.Data.Entity;
using SMSSender.Persistence.Entities;

namespace SMSSender.Persistence
{
    public interface ISmsSenderDb
    {
        DbContext DbContext { get; }

        DbSet<UserOrdersEntity> UsersOrders { get; set; }

        DbSet<MessageEntity> Messages { get; set; }
    }
}