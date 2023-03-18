using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.TemplateDefault
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TemplateDefaultParam Param { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    Domain.TemplateDefault newTem = _mapper.Map<Domain.TemplateDefault>(request.Param);

                    _context.TemplateDefaults.Add(newTem);

                    await _context.SaveChangesAsync(cancellationToken);

                    return Result<Unit>.Success(new Unit());

                }
                catch (Exception ex)
                {
                    return Result<Unit>.Failure(ex.Message);
                }
            }
        }
    }
}

