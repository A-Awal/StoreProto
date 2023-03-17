using Application.Stripe.Resources;

namespace Api.Services
{
    public interface IStripeService
    {
        Task<CustomerResource> CreateCustomer(CreateCustomerParam resource, CancellationToken cancellationToken);
        Task<ChargeResource> CreateCharge(CreateChargeParam resource, CancellationToken cancellationToken);
    }
}