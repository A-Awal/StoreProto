namespace Application.Stripe.Resources
{
    public record CreateChargeParam 
    (
        string Currency, 
        long Amount, 
        string CustomerId, 
        string ReceiptEmail, 
        string Description
    );
    
}