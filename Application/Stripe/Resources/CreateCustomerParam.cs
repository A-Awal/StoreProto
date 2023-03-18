namespace Application.Stripe.Resources
{
    public record CreateCustomerParam(
        string Email, 
        string Name,
        Guid CustomerId,
        Guid StoreId,
        CreateCardParam Card
    );
}