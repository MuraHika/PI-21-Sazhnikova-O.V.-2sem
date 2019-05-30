using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class Storage
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        [ForeignKey("StorageId")]
        public virtual List<StorageEquipment> StorageEquipments { get; set; }
    }
}
