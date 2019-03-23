using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class Technics
    {
        public int Id { get; set; }
        [Required]
        public string TechnicsName { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("TechnicsId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("TechnicsId")]
        public virtual List<TechnicsEquipment> TechnicsEquipments { get; set; }
    }
}
