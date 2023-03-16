using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Customer.Resources
{
    public record PurchaseParam(Guid ProductId, Guid CustomerId, int Quauntity);
    
}