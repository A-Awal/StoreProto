namespace Application.Stripe.Resources
{
    public record CustomerResource(
    string CustomerId, 
    string Email, 
    string Name
    );
}