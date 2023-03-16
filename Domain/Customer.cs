using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer: Merchant
	{
		public string Username { get; set; }
		public ICollection<Purchase> Purchases { get; set; }
		public ICollection<CustomerReview> ProductReviews {get; set;} = new List<CustomerReview>();
	}
}