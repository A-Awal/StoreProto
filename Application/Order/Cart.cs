using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Order
{
    public class Cart
    {
        public class Query: IRequest<Result<OrderDto>>
        {
        public  Guid CustomerId { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<OrderDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Any(c => c.Id == request.CustomerId);
                if (!customer) return Result<OrderDto>.Failure("Customer does not exist");
                
                var cart = await _context.Orders
                    .Include(o => o.Purchases)
                    .AsNoTracking()
                    .Where(o => o.CustomerId == request.CustomerId && o.OrderState == Domain.OrderStates.cart)
                    .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                if (cart == null) return Result<OrderDto>.Failure("Customer does not exist");

                return Result<OrderDto>.Success(cart);
            }
        }
    }
}
