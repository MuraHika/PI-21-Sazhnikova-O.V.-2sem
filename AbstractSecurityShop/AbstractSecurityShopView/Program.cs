using AbstractSecurityShopServiceImplementList.Implementation;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using AbstractSecurityShopView;
using System.Data.Entity;
using AbstractSecurityShopServiceImplementDataBase.Implementation;
using AbstractSecurityShopServiceImplementDataBase;

namespace AbstractGiftShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractSecurityShopDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentService, EquipmentServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITechnicsService, TechnicsServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReptService, ReptServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
