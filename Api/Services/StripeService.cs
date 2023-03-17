using Application.Stripe.Resources;
using Stripe;

namespace Api.Services
{

    public class StripeService : IStripeService
    {
        private readonly TokenService _tokenService;
        private readonly CustomerService _customerService;
        private readonly ChargeService _chargeService;

        public StripeService(
            TokenService tokenService,
            CustomerService customerService,
            ChargeService chargeService
        )
        {
            _tokenService = tokenService;
            _customerService = customerService;
            _chargeService = chargeService;
        }

        public async Task<CustomerResource> CreateCustomer(
            CreateCustomerParam param,
            CancellationToken cancellationToken
        )
        {
            var tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = param.Card.Name,
                    Number = param.Card.Number,
                    ExpYear = param.Card.ExpiryYear,
                    ExpMonth = param.Card.ExpiryMonth,
                    Cvc = param.Card.Cvc
                }
            };
            var token = await _tokenService.CreateAsync(tokenOptions, null, cancellationToken);

            var customerOptions = new CustomerCreateOptions
            {
                Email = param.Email,
                Name = param.Name,
                Source = token.Id
            };
            var customer = await _customerService.CreateAsync(
                customerOptions,
                null,
                cancellationToken
            );

            return new CustomerResource(customer.Id, customer.Email, customer.Name);
        }

        public async Task<ChargeResource> CreateCharge(
            CreateChargeParam Param,
            CancellationToken cancellationToken
        )
        {
            var chargeOptions = new ChargeCreateOptions
            {
                Currency = Param.Currency,
                Amount = Param.Amount,
                ReceiptEmail = Param.ReceiptEmail,
                Customer = Param.CustomerId,
                Description = Param.Description
            };

            var charge = await _chargeService.CreateAsync(chargeOptions, null, cancellationToken);

            return new ChargeResource(
                charge.Id,
                charge.Currency,
                charge.Amount,
                charge.CustomerId,
                charge.ReceiptEmail,
                charge.Description
            );
        }
    }
    
}