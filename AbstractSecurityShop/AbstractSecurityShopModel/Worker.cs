using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        public string WorkerFIO { get; set; }
        [ForeignKey("WorkerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
