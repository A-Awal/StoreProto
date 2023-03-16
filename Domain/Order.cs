namespace Domain
{
    public class Order
    {
        public Guid OrderId {get; set;}
        public Guid CustomerId { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public DateTime DateOrdered { get; set; } = DateTime.UtcNow;
        public Decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public OrderStates OrderState { get; set; }

    }

    public enum OrderStates
    {
        processing,
        shipping,
        delivered
    }
}