using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.BindingModel
{
    [DataContract]
    public class TechnicsEquipmentBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TechnicsId { get; set; }
        [DataMember]
        public int EquipmentId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
