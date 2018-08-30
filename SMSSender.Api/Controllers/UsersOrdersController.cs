using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using SMSSender.Domain.Services;
using SMSSender.Entities.Dtos;

namespace SMSSender.Api.Controllers
{
    [Route("UsersOrders")]
    public class UsersOrdersController: ApiController
    {
        private readonly IUserOrdersService _userOrdersService;

        public UsersOrdersController(IUserOrdersService userOrdersService)
        {
            this._userOrdersService = userOrdersService;
        }

        [HttpGet]
        public Task<List<UserOrder>> Get(CancellationToken cancellationToken)
        {
            return _userOrdersService.GetAllUsersOrders(cancellationToken);
        }
    }
}
