namespace Application.Stripe
{
	public class CreateChargeParamDto
    { 
        public string Description {get; set;}
        public string ReceiptEmail {get; set;} 
        public string CustomerId {get; set;} 
        public string Currency { get; set; }
        public long Amount {get; set;}
    }
}