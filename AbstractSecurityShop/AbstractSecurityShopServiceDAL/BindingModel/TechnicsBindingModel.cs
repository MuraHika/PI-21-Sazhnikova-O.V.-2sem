using AbstractSecurityShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.BindingModel
{
    [DataContract]
    public class TechnicsBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TechnicsName { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public List<TechnicsEquipmentBindingModel> TechnicsEquipment { get; set; }
    }
}
