using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    [DataContract]
    public class TechnicsViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TechnicsName { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public List<TechnicsEquipmentViewModel> TechnicsEquipment { get; set; }
    }
}
