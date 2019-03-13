using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    public class StorageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Хранилище")]
        public string StorageName { get; set; }
        public List<StorageEquipmentViewModel> StorageEquipment { get; set; }
    }
}
