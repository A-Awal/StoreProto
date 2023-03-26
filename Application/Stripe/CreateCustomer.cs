using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Stripe
{
    public class CreateCustomer
    {
        public class Query : IRequest<Result<CustomerResource>>
        {
            public CreateCustomerParam CreateCustomerParam { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CustomerResource>>
        {
            private readonly AppDataContext _context;
            private readonly IStripeService _stripeService;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IStripeService stripeService, IMapper mapper)
            {
                _context = context;
                _stripeService = stripeService;
                _mapper = mapper;
            }

            public async Task<Result<CustomerResource>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                try
                {
                    var stripeCustomerResource = await _stripeService.CreateCustomer(
                        request.CreateCustomerParam,
                        cancellationToken
                    );

                    var newCreditCard = _mapper.Map<Domain.CreditCardDetail>(
                        request.CreateCustomerParam
                    );

                    _context.CreditCardDetails.Add(newCreditCard);
                    var success = await _context.SaveChangesAsync() > 0;

                    if (!success)
                        return Result<CustomerResource>.Failure("Failed to create Card");

                    return Result<CustomerResource>.Success(stripeCustomerResource);
                }
                catch (Exception ex)
                {
                    return Result<CustomerResource>.Failure(ex.Message);
                }
            }
        }
    }
}
