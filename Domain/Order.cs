using System;
namespace Domain
{
    public class Order
	{
		public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public int QuantityOrdered { get; set; }
		public DateTime DateOrdered { get; set; } = DateTime.UtcNow;
		public OrderState OrderState { get; set; }
	}

	public enum OrderState
	{
		cart,
		pending,
		purchased
	}
}
