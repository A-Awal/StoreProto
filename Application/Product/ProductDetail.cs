using Domain;

namespace Application.Product
{
    public class ProductDetail : ProductAbstract
	{
		public List<Purchase> Purchases { get; set; }
		public ICollection<CustomerReview> Reviews { get; set; }
		public ICollection<ProductPhoto> ProductPhotos { get; set; }
	}
}
