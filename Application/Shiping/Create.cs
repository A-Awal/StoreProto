using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Shiping
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateShipingParam Param { get; set; }
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

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var ShippingDetail = _context.ShipingDetails
                    .FirstOrDefault( o => o.CustomerId == request.Param.CustomerId && o.StoreId == request.Param.StoreId);

                if (ShippingDetail != null) return Result<Unit>.Failure("request failed");

                var newshippingDetail = _mapper.Map<Domain.ShipingDetails>(request.Param);

                _context.ShipingDetails.Add(newshippingDetail);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success( new MediatR.Unit());

            }

        }
    }
}
