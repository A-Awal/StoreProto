using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Customer.Resources
{
    public record CustomerParam(
    string CustomerId, 
    string Email, 
    string Name
    );
}