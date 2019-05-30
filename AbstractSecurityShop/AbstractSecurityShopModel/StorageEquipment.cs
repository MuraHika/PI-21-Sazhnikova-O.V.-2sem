using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class StorageEquipment
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int EquipmentId { get; set; }
        public int Count { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
