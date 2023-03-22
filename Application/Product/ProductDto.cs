using Application.Purchase;
namespace Application.Product
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public Guid StoreId { get; set; }
        public string Store { get; set; }
    }
}
