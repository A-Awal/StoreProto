namespace Application.Order
{
    public class QueryParams
    {
        public Guid? customerId { get; set; }
        public Guid? storeId {get; set;}
        public bool Cart { get; set; } = false;
    }
}