using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Store
{
    public record CreateStoreParam(Guid MerchantId, string storeName);
    
}
