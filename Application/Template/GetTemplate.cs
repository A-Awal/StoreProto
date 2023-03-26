using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Template
{
    public class GetTemplate
    {
        public class Query : IRequest<Result<List<TemplateDto>>>
        {
            public string Category { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<TemplateDto>>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<TemplateDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var templates = await _context.Templates
                    .Include(t => t.TemplatePhotos)
                    .Where(t => t.TemplateCategory.Contains(request.Category))
                    .ToListAsync();

                if (templates == null)
                {
                    return Result<List<TemplateDto>>.Failure("This category does not exist");
                }

                var toReturn = _mapper.Map<List<TemplateDto>>(templates);

                return Result<List<TemplateDto>>.Success(toReturn);
            }
        }
    }
}
