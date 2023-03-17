using Api.Services;
using Application.Stripe.Resources;
using MediatR;
using Persistence;

namespace Application.Stripe
{
    public class CreateCustomer
    {
        public class Query: IRequest<CustomerResource>
        {
            public CreateCustomerParam param { get; set; }
        }

        public class Handler : IRequestHandler<Query, CustomerResource>
        {
            private readonly AppDataContext _context;
            private readonly IStripeService _stripeService;

            public Handler(AppDataContext context, IStripeService stripeService)
            {
                _context = context;
                _stripeService = stripeService;
            }

            public async Task<CustomerResource> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _stripeService.CreateCustomer(request.param, cancellationToken);
                return response;
            }
        }
    }
}