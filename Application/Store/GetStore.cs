using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Store
{
    public class GetStore
    {
        public class Query : IRequest<Result<List<StoreDto>>>
        {
            public Guid StoreId { get; set; }
			public Guid MerchantId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<StoreDto>>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<StoreDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
				var store = _context.Stores.Where(s => s.MerchantId == request.MerchantId).AsQueryable();

                if (store != null)
                {
					if(request.StoreId != Guid.Empty)
					{
						store = store.Where(s => s.StoreId == request.StoreId);
					}

					var storeDto = _mapper.Map<List<StoreDto>>(store);

					return Result<List<StoreDto>>.Success(storeDto);
                }

                return Result<List<StoreDto>>.Failure("Store does not exist");
            }
        }
    }
}
