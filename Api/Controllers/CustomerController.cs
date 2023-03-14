using Application.Order;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class CustomerController : BaseApiController
    {
        [HttpGet]
        public async Task Cart(string customerId)
        {
            var id = Guid.Parse(customerId);
            return HandleResult( await Mediator.Send(  new Orders.Query.Params{ CustomerId=customerId, Cart = true} ));
        }
    }
}