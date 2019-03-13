﻿using AbstractSecurityShopServiceImplementList.Implementation;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using AbstractSecurityShopView;

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
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentService, EquipmentServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITechnicsService, TechnicsServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceList>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
