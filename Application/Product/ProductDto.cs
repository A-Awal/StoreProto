using Application.Photos;
using Domain;

namespace Application.Product
{
	public class ProductDto : ProductAbstract
    {
        public Guid ProductId { get; set; }
        public string StoreName { get; set; }
        public List<PhotoUploadResult> ProductPhotos { get; set; } 

    }
}