namespace Application.Shiping
{
    public record CreateShipingParam(Guid StoreId, Guid CustomerId, string Location);
}
