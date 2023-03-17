namespace Application.Stripe.Resources
{
    public record CreateCustomerParam(
        string Email, 
        string Name, 
        CreateCardParam Card
    );
}