using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Хранилище")]
        public string StorageName { get; set; }
        [DataMember]
        public List<StorageEquipmentViewModel> StorageEquipment { get; set; }
    }
}
