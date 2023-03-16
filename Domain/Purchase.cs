using System;
namespace Domain
{
    public class Purchase
	{
		public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public Guid OrderId { get; set; }
		public Product Product { get; set; }
		public int QuantityPurchased { get; set; }
		public DateTime DatePurchased { get; set; } = DateTime.UtcNow;
		public PurchaseState PurchaseState { get; set; }
		public Order Order {get; set; }
	}

	public enum PurchaseState
	{
		cart,
		pending,
		purchased
	}
}
