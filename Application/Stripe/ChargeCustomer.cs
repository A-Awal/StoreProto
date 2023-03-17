using Api.Services;
using Application.Services;
using Application.Stripe.Resources;
using MediatR;
using Persistence;

namespace Application.Stripe
{
    public class ChargeCustomer
    {
        public class Query: IRequest<ChargeResource>
        {
            public CreateChargeParam param { get; set; }
        }

        public class Handler : IRequestHandler<Query, ChargeResource>
        {
            private readonly AppDataContext _context;
            private readonly IStripeService _stripeService;
        private readonly IEmailSender _emailSender;

            public Handler(AppDataContext context, IStripeService stripeService, IEmailSender emailSender)
            {
                _emailSender = emailSender;
                _context = context;
                _stripeService = stripeService;
            }

            public async Task<ChargeResource> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _stripeService.CreateCharge(request.param, cancellationToken);
                
               
            
                return response;
            }
        }
    }
}