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
                    Domain.Template newTem = _mapper.Map<Domain.Template>(request.PageDto);
                    
                    _context.Templates.Add(newTem);
                    await _context.SaveChangesAsync(cancellationToken);

                    var newstore = _mapper.Map<PageDto>(newTem);

                    return Result<PageDto>.Success(newstore);
                }
                catch(Exception ex)
                {
                    return Result<PageDto>.Failure(ex.Message);
                }
                
            }
        }
    }
}
