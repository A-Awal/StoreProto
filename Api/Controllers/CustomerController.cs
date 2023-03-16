using Application.Purchase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class CustomerController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Cart(string customerId)
        {
            var id = Guid.Parse(customerId);
            return HandleResult(await _mediator.Send( new Purchases.Query{Params={ CustomerId = id, Cart = true }} ));
        }
    }
}