using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopModel
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TechnicsId { get; set; }
        public int? WorkerId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Technics Technics { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
