using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.BindingModel
{
    public class TechnicsEquipmentBindingModel
    {
        public int Id { get; set; }
        public int TechnicsId { get; set; }
        public int EquipmentId { get; set; }
        public int Count { get; set; }
    }
}
