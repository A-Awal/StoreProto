using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Stripe
{
    public class ChargeCustomer
    {
        public class Query : IRequest<Result<ChargeResource>>
        {
            public CreateChargeParam CreateChargeParam { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ChargeResource>>
        {
            private readonly AppDataContext _context;
            private readonly IStripeService _stripeService;

            public Handler(AppDataContext context, IStripeService stripeService)
            {
                _context = context;
                _stripeService = stripeService;
            }

            public async Task<Result<ChargeResource>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                try
                {
                    var response = await _stripeService.CreateCharge(
                        request.CreateChargeParam,
                        cancellationToken
                    );

                    return Result<ChargeResource>.Success(response);
                }
                catch (Exception ex)
                {
                    return Result<ChargeResource>.Failure(ex.Message);
                }
            }
        }
    }
}
