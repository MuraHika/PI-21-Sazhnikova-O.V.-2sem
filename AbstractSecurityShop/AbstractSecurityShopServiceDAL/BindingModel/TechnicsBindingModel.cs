using AbstractSecurityShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.BindingModel
{
    public class TechnicsBindingModel
    {
        public int Id { get; set; }
        public string TechnicsName { get; set; }
        public int Price { get; set; }
        public List<TechnicsEquipmentBindingModel> TechnicsEquipment{ get; set; }
    }
}
