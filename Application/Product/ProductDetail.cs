using Application.Photos;
using Application.Purchases;
using Application.ReviewReplies;
using Application.Reviews;
using Domain;

namespace Application.Product
{
    public class ProductDetail : ProductAbstract
	{
		public ICollection<ReviewDto> Reviews { get; set; }
		public ICollection<PhotoUploadResult> ProductPhotos { get; set; }
	}
}
