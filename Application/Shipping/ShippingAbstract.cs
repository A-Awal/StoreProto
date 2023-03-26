namespace Application.Shipping
{
	public abstract class ShippingDetailsAbstract
    {
        public Guid StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShippingDetailsId { get; set; }
        public string Location { get; set; }
    }
}