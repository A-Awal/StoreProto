namespace Application.Purchase
{
    public class QueryParams
    {
        public Guid? CustomerId { get; set; }
        public Guid? StoreId {get; set;}
        public bool Cart { get; set; } = false;
    }
}