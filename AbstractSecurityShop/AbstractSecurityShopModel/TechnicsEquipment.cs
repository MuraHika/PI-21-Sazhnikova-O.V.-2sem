using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class TechnicsEquipment
    {
        public int Id { get; set; }
        public int TechnicsId { get; set; }
        public int EquipmentId { get; set; }
        [Required]
        public int Count { get; set; }
        public string EquipmentName { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Technics Technics { get; set; }
    }
}
