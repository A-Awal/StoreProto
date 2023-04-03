using Domain;

namespace Application.Purchases
{
	public class PurchaseDto : PurchaseAbstract
	{
		public Guid OrderId { get; set; }
		public string Product { get; set; }
		public DateTime DatePurchased { get; set; }
		public string PurchaseState { get; set; }
		public Guid Order { get; set; }
		public decimal Discount { get; set; }
		public decimal DiscountAmount { get; set; }
		public	decimal AmountDue { get; set; }
		public string UnitOfMeasurement {get; set;}
	}
}
