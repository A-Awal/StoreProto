namespace Domain
{
    public class Customer: Merchant
	{
		public string Username { get; set; }
		public Guid OrderId {get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<CustomerReview> ProductReviews {get; set;} = new List<CustomerReview>();
	}
}
