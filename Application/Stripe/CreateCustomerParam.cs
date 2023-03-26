namespace Application.Stripe
{
	public record CreateCustomerParam(
        string Email, 
        string Name,
        Guid CustomerId,
        Guid StoreId,
        CreateCardParam Card
    );
}