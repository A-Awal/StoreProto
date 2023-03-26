namespace Application.Stripe
{
	public class ConfirmationInfo : CreateChargeParamDto
    {
        public CustomerResource CustomerResource {get; set; }
    }
}
    