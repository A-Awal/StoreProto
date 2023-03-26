using System;
using Application.Orders;
using Application.Purchases;
using Application.Stripe;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CustomerController : BaseApiController
    {
        [HttpPost("purchase")]
        public async Task<IActionResult> PuchaseAProduct(PurchaseCreateParam purchaseCreateParam)
        {
            var result = await Mediator.Send(
                new Application.Orders.Create.Command
                {
                    OrderCreateParam = new OrderCreateParam(purchaseCreateParam.CustomerId)
                }
            );

            if (!result.IsSuccess)
                return HandleResult(result);

            return HandleResult(
                await Mediator.Send(
                    new Application.Purchases.Create.Command
                    {
                        PurchaseCreateParam = purchaseCreateParam,
                        OrderId = result.Value
                    }
                )
            );
        }

        [HttpGet("Cart")]
        public async Task<IActionResult> Cart(Guid customerId)
        {
            return HandleResult(
                await Mediator.Send(new Application.Orders.Cart.Query { CustomerId = customerId })
            );
        }

        [HttpPost("SubmitStripeDetails")]
        public async Task<IActionResult> SubmitStripeDetails(
            CreateCustomerParam createCustomerParam,
            Guid DbCustomerId
        )
        {
            var resource = await Mediator.Send(
                new CreateCustomer.Query { CreateCustomerParam = createCustomerParam }
            );
            if (!resource.IsSuccess)
                return Problem(resource.Error);

            CustomerResource customerResource = resource.Value;

            var cart = await Mediator.Send(new Cart.Query { CustomerId = DbCustomerId });
            decimal amount = cart.Value.TotalAmount;

            if (!cart.IsSuccess)
                return Problem(cart.Error);

            ConfirmationInfo confirmationInfo = new ConfirmationInfo();
            confirmationInfo.CustomerResource = customerResource;
            confirmationInfo.Amount = (long)amount;

            return Ok(confirmationInfo);
        }

        [HttpGet("getCard")]
        public async Task<IActionResult> GetCardDetails(CreateCustomerParam createCustomerParam)
        {
            return HandleResult(
                await Mediator.Send(
                    new GetCardDetails.Query { CreateCustomerParam = createCustomerParam }
                )
            );
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(CreateChargeParam chargeParam, Guid DbCustomerId)
        {
            var processPurchase = await Mediator.Send(
                new PrepareForPayment.Command { CustomerId = DbCustomerId }
            );

            if (!processPurchase.IsSuccess)
                return Problem(processPurchase.Error);

            return HandleResult(
                await Mediator.Send(new ChargeCustomer.Query() { CreateChargeParam = chargeParam })
            );
        }
    }
}
