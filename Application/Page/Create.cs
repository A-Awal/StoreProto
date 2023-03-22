using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Page
{
    public class Create
    {
        public class Command: IRequest<Result<PageDto>>
        {
            public PageDto PageDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<PageDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PageDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var store = _context.Stores.Find(request.PageDto.StoreId);

                if (store == null) return Result<PageDto>.Failure("store does not exist");

                try
                {
                    Domain.Page newTem = _mapper.Map<Domain.Page>(request.PageDto);
                    
                    _context.Pages.Add(newTem);
                    await _context.SaveChangesAsync(cancellationToken);

                    var newpage = _mapper.Map<PageDto>(newTem);

                    return Result<PageDto>.Success(newpage);
                }
                catch(Exception ex)
                {
                    return Result<PageDto>.Failure(ex.Message);
                }
                
            }
        }
    }
}
