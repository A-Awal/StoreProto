namespace Domain
{
    public class Store
	{
        public Guid StoreId { get; set; }
		public Guid MerchantId { get; set; }
        public Merchant Merchant { get; set; }
		public ICollection<Page> Pages { get; set; } = new List<Page>();
        public string StoreName { get; set; }
		public ICollection<Product> Inventory { get; set; }
		public ICollection<ShipingDetails> shipingDetails { get; set; }
	}

}
