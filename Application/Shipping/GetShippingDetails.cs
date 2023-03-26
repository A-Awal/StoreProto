using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Shipping
{
    public class Get
    {
        public class Query : IRequest<Result<ShippingDto>>
        {
            public GetParam GetParam { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ShippingDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ShippingDto>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var shippingDetails = await _context.ShipingDetails.FirstOrDefaultAsync(
                    s =>
                        s.CustomerId == request.GetParam.CustomerId
                        && s.StoreId == request.GetParam.StoreId
                );

                if (shippingDetails == null)
                    return Result<ShippingDto>.Failure("customer has no details yet");

                var details = _mapper.Map<ShippingDto>(shippingDetails);

                return Result<ShippingDto>.Success(details);
            }
        }
    }
}
