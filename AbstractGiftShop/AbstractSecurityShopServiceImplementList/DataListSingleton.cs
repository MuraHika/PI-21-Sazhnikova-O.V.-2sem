using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractSecurityShopModel;

namespace AbstractSecurityServiceImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<Order> Orders { get; set; }
        public List<Technics> Technics { get; set; }
        public List<TechnicsEquipment> TechnicsEquipment { get; set; }
        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Equipment = new List<Equipment>();
            Orders = new List<Order>();
            Technics = new List<Technics>();
            TechnicsEquipment = new List<TechnicsEquipment>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
