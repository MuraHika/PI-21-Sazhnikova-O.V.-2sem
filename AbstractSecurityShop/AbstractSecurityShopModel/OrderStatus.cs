using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public enum OrderStatus
    {
        Accepted = 0,
        Processed = 1,
        Ready = 2,
        Paid = 3,
        NotEnoughRes = 4
    }
}
