namespace Application.Product
{
    public class ProductCreateParam
    {
        public Guid StoreId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Quantity { get; set; }
    }
}