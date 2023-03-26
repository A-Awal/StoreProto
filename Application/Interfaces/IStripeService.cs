using Application.Stripe;

namespace Application.Interfaces
{
	public interface IStripeService
    {
        Task<CustomerResource> CreateCustomer(CreateCustomerParam resource, CancellationToken cancellationToken);
        Task<ChargeResource> CreateCharge(CreateChargeParam resource, CancellationToken cancellationToken);
    }
}