using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class Update
    {
        public class Command : IRequest<Result<TemplateDto>>
        {
            public TemplateUpdateParam TemplateUpdateParam { get; set; }
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

            public async Task<Result<TemplateDto>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var templateToUpdate = _context.Templates.Find(
                    request.TemplateUpdateParam.TemplateId
                );
                if (templateToUpdate == null)
                    return Result<TemplateDto>.Failure("template does not exist");

                try
                {
                    templateToUpdate.Address = request.TemplateUpdateParam.Address;
                    templateToUpdate.TemplateCategory = request
                        .TemplateUpdateParam
                        .TemplateCategory;
                    templateToUpdate.TemplateNumber = request.TemplateUpdateParam.TemplateNumber;
                    templateToUpdate.Heading = request.TemplateUpdateParam.Heading;
                    templateToUpdate.SubHeading = request.TemplateUpdateParam.SubHeading;
                    templateToUpdate.MainColor = request.TemplateUpdateParam.MainColor;
                    templateToUpdate.SubColor = request.TemplateUpdateParam.SubColor;
                    templateToUpdate.FooterText = request.TemplateUpdateParam.FooterText;
                    templateToUpdate.InstagramLink = request.TemplateUpdateParam.InstagramLink;
                    templateToUpdate.FacebookLink = request.TemplateUpdateParam.FacebookLink;
                    templateToUpdate.TwitterLink = request.TemplateUpdateParam.TwitterLink;
                    templateToUpdate.PhoneNumber = request.TemplateUpdateParam.PhoneNumber;
                    templateToUpdate.StoreName = request.TemplateUpdateParam.StoreName;

                    _context.Templates.Update(templateToUpdate);
                    await _context.SaveChangesAsync();

                    var templateToReturn = _mapper.Map<TemplateDto>(templateToUpdate);

                    return Result<TemplateDto>.Success(templateToReturn);
                }
                catch (Exception ex)
                {
                    return Result<TemplateDto>.Failure(ex.Message);
                }
            }
        }
    }
}
