using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Order
{
    public class Orders
    {
        public class Query: IRequest<Result<List<OrderDto>>>
        {
            public QueryParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<OrderDto>>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<OrderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Orders
                    .OrderBy(o => o.DateOrdered)
                    .AsQueryable();

                if(request.Params.customerId != null) 
                {
                    query = query.Where(o => o.CustomerId == request.Params.customerId);
                }

                if(request.Params.storeId != null) 
                {
                    query = query.Where(o => o.Product.StoreId == request.Params.storeId);
                }
                
                if(request.Params.Cart) 
                {
                    query = query.Where(o => o.OrderState ==  OrderState.cart);
                }

                var orders = await query.ToListAsync();

                var  ordersToSend = _mapper.Map<List<OrderDto>>(orders);
                return  Result<List<OrderDto>>.Success(ordersToSend);


            }
        }
    }
}