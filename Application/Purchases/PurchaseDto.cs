using Domain;

namespace Application.Purchases
{
    public class PurchaseDto : PurchaseAbstract
    {
        public Guid OrderId { get; set; }
        public string Product { get; set; }
        public DateTime DatePurchased { get; set; }
        public PurchaseState PurchaseState { get; set; }
        public Guid Order { get; set; }
    }
}
