using System.Data.Entity;
using SMSSender.Persistence.Entities;
using SMSSender.Persistence.Repositories.Base;

namespace SMSSender.Persistence.Repositories
{
    public class MessageRepository : CrudRepositoryBase<MessageEntity>, IMessageRepository
    {
        public MessageRepository(IDbProvider<ISmsSenderDb> dbProvider) : base(dbProvider)
        {
        }

        protected override DbSet<MessageEntity> GetDbSet()
        {
            return this.Db.Messages;
        }
    }
}