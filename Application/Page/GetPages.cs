using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Page
{
    public class GetPages
    {
        public class Query : IRequest<Result<PageDto>>
        {
            public GetPageParam GetPageParam { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PageDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var defaultTemplate = _context.Pages
                    .Where(t => t.StoreId == request.GetPageParam.StoreId)
                    .AsQueryable();
                if(request.GetPageParam.PageId != Guid.Empty)
                {
                    defaultTemplate = defaultTemplate.Where( d => d.PageId == request.GetPageParam.PageId);
                }

                if (defaultTemplate == null)
                {
                    return Result<PageDto>.Failure("This category does not exist");
                }

                var toReturn = _mapper.Map<PageDto>(defaultTemplate);

                return Result<PageDto>.Success(toReturn);
            }
        }
    }
}
