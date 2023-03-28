using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Store
{
    public class GetStore
    {
        public class Query : IRequest<Result<StoreDto>>
        {
            public Guid StoreId { get; set; }
			public Guid MerchantId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<StoreDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<StoreDto>> Handle(
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

					var storeDto = _mapper.Map<StoreDto>(store);

					return Result<StoreDto>.Success(storeDto);
                }

                return Result<StoreDto>.Failure("Store does not exist");
            }
        }
    }
}
