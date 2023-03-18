using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCardDetail
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; } = string.Empty;
        public string ExpiryYear { get; set; }
        public string ExpiryMonth { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public string Cvc { get; set; }

    }
}
