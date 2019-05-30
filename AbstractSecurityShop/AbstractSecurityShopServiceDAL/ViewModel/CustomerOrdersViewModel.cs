using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    public class CustomerOrdersViewModel
    {
        public string CustomerFIO { get; set; }
        public string DateCreate { get; set; }
        public string TechnicsName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
