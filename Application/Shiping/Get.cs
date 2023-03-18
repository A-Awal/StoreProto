using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Shiping
{
    public class Get
    {
        public class Query: IRequest<Result<CreateShipingParam>>
        {
           public GetshippingDetailParams Params { get; set;}
        }

        public class Handler : IRequestHandler<Query, Result<CreateShipingParam>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<CreateShipingParam>> Handle(Query request, CancellationToken cancellationToken)
            {
                var shippingDetals = _context.ShipingDetails
                    .FirstOrDefaultAsync(s => s.CustomerId == request.Params.CustomerId && s.StoreId == request.Params.StoreId);

                if (shippingDetals == null) return Result<CreateShipingParam>.Failure("customer has no details yet");

                var details  = _mapper.Map<CreateShipingParam>(shippingDetals);

                return Result<CreateShipingParam>.Success(details);
            }
        }
    }
}
