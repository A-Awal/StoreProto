using Application.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto (string publicId);
    }
}