namespace Domain
{
    public class Store
	{
        public Guid StoreId { get; set; }
		public Guid MerchantId { get; set; }
        public Merchant Merchant { get; set; }
		public ICollection<Template> Template { get; set; } = new List<Template>();
        public string StoreName { get; set; }
		public ICollection<Product> Inventory { get; set; }
	}

}
