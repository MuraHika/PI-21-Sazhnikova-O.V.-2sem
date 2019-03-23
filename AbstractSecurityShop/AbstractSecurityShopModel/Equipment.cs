using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class Equipment
    {
        public int Id { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual List<TechnicsEquipment> TechnicsEquipments { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual List<StorageEquipment> StorageEquipments { get; set; }
    }
}
