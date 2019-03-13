using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    public class TechnicsViewModel
    {
        public int Id { get; set; }
        public string TechnicsName { get; set; }
        public decimal Price { get; set; }
        public List<TechnicsEquipmentViewModel> TechnicsEquipment { get; set; }
    }
}
