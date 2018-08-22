using SMSSender.Persistence.Entities;
using SMSSender.Persistence.Repositories.Base;

namespace SMSSender.Persistence.Repositories
{
    public interface IMessageRepository: ICrudRepository<MessageEntity>
    {
    }
}