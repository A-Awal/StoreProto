using Application.Purchase;
using Application.Stripe;
using Application.Stripe.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class CustomerController : BaseApiController
    {
        

        [HttpGet("Submit-a-Purchase")]
        public async Task<IActionResult> PuchaseAProduct(PurchaseDto purchase)
        {
            Guid cartId = await Mediator.Send(new Application.Order.Create.Query{purchaseDto = purchase});

            return HandleResult(await Mediator.Send(new Application.Purchase.Create.Command { cartId = cartId, purchaseDto = purchase }));
            
        }

        [HttpGet]
        public async Task<IActionResult> Cart(string customerId)
        {
            var id = Guid.Parse(customerId);
            return HandleResult(await Mediator.Send( new Purchases.Query{Params={ CustomerId = id, Cart = true }} ));
        }

        [HttpPost("SubmitStripeDetails")]
        public async Task<IActionResult> SubmitStripeDetails(CreateCustomerParam para)
        {
            return Ok(await Mediator.Send(new CreateCustomer.Query{param = para }));
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(CreateChargeParam para)
        {
            return Ok(await Mediator.Send(new ChargeCustomer.Query(){param = para }));
        }

        

    }
}