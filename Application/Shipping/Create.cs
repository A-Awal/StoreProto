using Application.Core;
using Application.Purchases;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Shipping
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ShippingParam ShippingParam { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var newshippingDetail = _mapper.Map<Domain.ShippingDetails>(request.ShippingParam);

                _context.ShipingDetails.Add(newshippingDetail);

                var success = await _context.SaveChangesAsync() > 0;

                if (!success)
                    return Result<Unit>.Failure("Unable to add new shippingDetails");

                return Result<Unit>.Success(new MediatR.Unit());
            }
        }
    }
}
