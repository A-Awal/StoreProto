namespace Application.Purchase
{
    public class PurchaseDto
    {
    
    public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public int QuantityPurchase { get; set; }
    }
}