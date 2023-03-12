using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer: Merchant
	{
		public string Username { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
