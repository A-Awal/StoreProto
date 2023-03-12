using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
	public abstract class User{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }
	}

    public class Merchant: User
	{
        public Guid MerchantID { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
