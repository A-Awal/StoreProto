using Domain;

namespace Application.Purchases
{
	public abstract class PurchaseAbstract
    {
        public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public int QuantityPurchased { get; set; }

    }
}