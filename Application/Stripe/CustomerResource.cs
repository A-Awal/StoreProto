namespace Application.Stripe
{
	public record CustomerResource
    (
    string CustomerId, 
    string Email, 
    string Name
    );
}