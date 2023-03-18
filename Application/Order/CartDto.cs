using Domain;

namespace Application.Order
{
    public class CartDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public List<Domain.Purchase> Purchases { get; set; } = new List<Domain.Purchase>();
        public DateTime DateOrdered { get; set; } = DateTime.UtcNow;
        public Decimal TotalAmount { get; set; }
        public Domain.Customer Customer { get; set; }
        public OrderStates OrderState { get; set; }
    }
}
