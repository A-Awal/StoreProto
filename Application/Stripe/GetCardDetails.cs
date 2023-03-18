using Api.Services;
using Application.Core;
using Application.Stripe.Resources;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Stripe
{
    public class GetCardDetails
    {
        public class Query : IRequest<Result<CustomerResource>>
        {
            public CreateCustomerParam param { get; set; }
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

            public async Task<Result<CustomerResource>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.param.StoreId != Guid.Empty)
                {
                    var individualStoreCardDetail = _context.CreditCardDetails.Find(request.param.CustomerId, request.param.StoreId);

                    if (individualStoreCardDetail == null)
                    {
                        return Result<CustomerResource>.Failure("The customer has no details yet");
                    }

                    var CardReource = _mapper.Map<CustomerResource>(individualStoreCardDetail);
                    return Result<CustomerResource>.Success(CardReource);
                }

                // Since we treating merchant card details as one for now
                var response = _context.CreditCardDetails.First( c => c.CustomerId == request.param.CustomerId);

                if (response == null)
                {
                    return Result<CustomerResource>.Failure("The customer has no details yet");
                }
                var cardDetails = _mapper.Map<CustomerResource>(response);

                return Result<CustomerResource>.Success(cardDetails);


            }
        }
    }
}
