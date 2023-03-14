namespace Application.Order
{
    public class OrderDto
    {
    
    public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public int QuantityOrdered { get; set; }
    }
}