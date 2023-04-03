namespace Application.Product
{
	public class ProductDto : ProductAbstract
    {
        public Guid ProductId { get; set; }
        public string StoreName { get; set; }
        
    }
}