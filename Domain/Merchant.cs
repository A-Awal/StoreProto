namespace Domain
{
    public class User{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }
		public DateTime DateCreated { get; set; }
	}

    public class Merchant: User
	{
        public ICollection<Store> Stores { get; set; }
		public ICollection<ReviewReply> ReviewReplies { get; set; } = new List<ReviewReply>();
    }
}
