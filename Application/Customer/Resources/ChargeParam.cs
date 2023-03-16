using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Customer.Resources
{
    public public record ChargeParam
    ( 
        string ChargeId,
        string Currency,
        long Amount,
        string CustomerId,
        string ReceiptEmail,
        string Description
    )
}
