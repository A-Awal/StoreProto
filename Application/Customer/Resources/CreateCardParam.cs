using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Customer.Resources
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