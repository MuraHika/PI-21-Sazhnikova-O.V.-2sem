using AbstractSecurityShopModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceImplementDataBase
{
    public class AbstractSecurityShopDbContext : DbContext
    {
        public AbstractSecurityShopDbContext() : base("AbstractSecurityShopDatabase1")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Technics> Technics { get; set; }
        public virtual DbSet<TechnicsEquipment> TechnicsEquipments { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StorageEquipment> StorageEquipments { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<MessageInfo> MessageInfos { get; set; }
    }
}
