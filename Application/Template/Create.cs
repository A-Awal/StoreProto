using Application.Core;
using Application.Store;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class Create
    {
        public class Command: IRequest<Result<TemplateDto>>
        {
            public TemplateDto TemplateDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<TemplateDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TemplateDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var store = _context.Stores.Find(request.TemplateDto.StoreId);

                if (store == null) return Result<TemplateDto>.Failure("store does not exist");

                try
                {
                    Domain.Template newTem = _mapper.Map<Domain.Template>(request.TemplateDto);
                    
                    _context.Templates.Add(newTem);
                    await _context.SaveChangesAsync(cancellationToken);

                    var newstore = _mapper.Map<TemplateDto>(newTem);

                    return Result<TemplateDto>.Success(newstore);
                }
                catch(Exception ex)
                {
                    return Result<TemplateDto>.Failure(ex.Message);
                }
                
            }
        }
    }
}
