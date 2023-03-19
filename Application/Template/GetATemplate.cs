using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Template
{
    public class GetATemplate
    {
        public class Query: IRequest<Result<TemplateCreateParam>>
        {
            public string Category { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TemplateCreateParam>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TemplateCreateParam>> Handle(Query request, CancellationToken cancellationToken)
            {
                var defaultTemplate = await _context.Templates.FirstOrDefaultAsync(t => t.TemplateCategory.Contains(request.Category));
                if (defaultTemplate == null)
                {
                    return Result<TemplateCreateParam>.Failure("This category does not exist");
                }

                var toReturn = _mapper.Map<TemplateCreateParam>(defaultTemplate);
                return Result<TemplateCreateParam>.Success(toReturn);
            }
        }
    }
}
