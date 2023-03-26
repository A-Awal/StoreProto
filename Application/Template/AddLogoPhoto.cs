using Application.Core;
using Application.Interfaces;
using Application.Photos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Template
{
    public class AddLogoPhoto
    {
        public class Command : IRequest<Result<PhotoUploadResult>>
        {
            public IFormFile LogoPhoto { get; set; }
            public Guid TemplateId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<PhotoUploadResult>>
        {
            private readonly AppDataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IPhotoAccessor photoAccessor, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<PhotoUploadResult>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var template = _context.Templates.Find(request.TemplateId);

                if (template == null)
                    return Result<PhotoUploadResult>.Failure("Template does not exist");

                try
                {
                    var logo = await _photoAccessor.AddPhoto(request.LogoPhoto);
                    template.Logo = logo.PublicId;

                    TemplatePhoto logoPhoto = new TemplatePhoto
                    {
                        Id = logo.PublicId,
                        Url = logo.Url,
                        TemplateId = template.TemplateId
                    };

                    _context.TemplatePhotos.Add(logoPhoto);

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success)
                    {
                        var result = _mapper.Map<PhotoUploadResult>(logoPhoto);

                        return Result<PhotoUploadResult>.Success(result);
                    }

                    return Result<PhotoUploadResult>.Failure("Couldn't upload photo");
                }
                catch (Exception ex)
                {
                    return Result<PhotoUploadResult>.Failure(ex.Message);
                }
            }
        }
    }
}
