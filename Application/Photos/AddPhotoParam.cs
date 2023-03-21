using Microsoft.AspNetCore.Http;

namespace Application.Photos
{
    public record AddPhotoParam(IFormFile HeroImage,  Guid Id );
    
}