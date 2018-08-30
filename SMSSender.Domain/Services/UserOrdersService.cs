using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Entities.Dtos;
using SMSSender.Persistence.Repositories;

namespace SMSSender.Domain.Services
{
    public class UserOrdersService : IUserOrdersService
    {
        private readonly IUserOrdersRepository _userOrdersRepository;

        public UserOrdersService(IUserOrdersRepository userOrdersRepository)
        {
            _userOrdersRepository = userOrdersRepository;
        }

        public Task<List<UserOrder>> GetAllUsersOrders(CancellationToken cancellationToken)
        {
            return _userOrdersRepository.Get()
                .Select(x => new UserOrder
                {
                    Id = x.Id,
                    OrderDateUtc = x.OrderDateUtc,
                    UserMobileNumber = x.UserMobileNumber
                })
                .ToListAsync(cancellationToken);
        }
    }
}