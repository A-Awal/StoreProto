namespace Domain
{
    public class ShipingDetails
    {
        public Guid StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Store store { get; set; }
        public string Location { get; set; }
    }
}
