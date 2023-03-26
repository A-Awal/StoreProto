using Domain;

namespace Application.Orders
{
	public class OrderDto: OrderAbstract
    {
        public List<Object> Purchases { get; set; }
        public string Customer { get; set; }
    }
}