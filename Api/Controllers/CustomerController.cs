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
            var result = await Mediator.Send(new Application.Order.Create.Command { purchaseDto = purchase });

            Guid cartId = result.Value;

            return HandleResult(await Mediator.Send(new Application.Purchase.Create.Command { cartId = cartId, purchaseDto = purchase }));
            
        }

        [HttpGet]
        public async Task<IActionResult> Cart(string customerId)
        {
            var id = Guid.Parse(customerId);
            return HandleResult(await Mediator.Send( new Application.Order.Cart.Query { CustomerId= id} ));
        }

        [HttpPost("SubmitStripeDetails")]
        public async Task<IActionResult> SubmitStripeDetails(CreateCustomerParam para)
        {
            return Ok(await Mediator.Send(new CreateCustomer.Query{param = para }));
        }

        [HttpGet("getCardCard")]
        public async Task<IActionResult> GetCardDetails(CreateCustomerParam para)
        {
            return HandleResult(await Mediator.Send(new GetCardDetails.Query{ param = para}));
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(CreateChargeParam para)
        {
            return Ok(await Mediator.Send(new ChargeCustomer.Query(){param = para }));
        }


    }
}