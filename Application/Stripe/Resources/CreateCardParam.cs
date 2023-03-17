namespace Application.Stripe.Resources
{
    public record CreateCardParam
    (
        string Name, 
        string Number, 
        string ExpiryYear, 
        string ExpiryMonth, 
        string Cvc
    );
}