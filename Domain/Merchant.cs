namespace Domain
{
	public class Merchant: User
	{
        public string BusinessName { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<ReviewReply> ReviewReplies { get; set; } = new List<ReviewReply>();
    }
}
