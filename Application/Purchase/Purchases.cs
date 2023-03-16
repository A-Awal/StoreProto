using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Purchase
{
    public class Purchases
    {
        public class Query: IRequest<Result<List<PurchaseDto>>>
        {
            public QueryParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<PurchaseDto>>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<PurchaseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Purchases
                    .OrderBy(o => o.DatePurchased)
                    .AsQueryable();

                if(request.Params.CustomerId != null) 
                {
                    query = query.Where(o => o.CustomerId == request.Params.CustomerId);
                }

                if(request.Params.StoreId != null) 
                {
                    query = query.Where(o => o.Product.StoreId == request.Params.StoreId);
                }

                if(request.Params.Cart) 
                {
                    query = query.Where(o => o.PurchaseState ==  PurchaseState.cart);
                }

                var Purchases = await query.ToListAsync();

                var  PurchasesToSend = _mapper.Map<List<PurchaseDto>>(Purchases);
                return  Result<List<PurchaseDto>>.Success(PurchasesToSend);


            }
        }
    }
}