using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Domain.Dtos;

namespace SMSSender.Domain.Services
{
    public interface IUserOrdersService
    {
        Task<List<UserOrder>> GetAllUsersOrders(CancellationToken cancellationToken);
    }
}