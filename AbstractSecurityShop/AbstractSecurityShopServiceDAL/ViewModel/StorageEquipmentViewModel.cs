using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    public class StorageEquipmentViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int EquipmentId { get; set; }
        [DisplayName("Название оборудования")]
        public string EquipmentName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
