using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    public interface IReptService
    {
        void SaveTechnicsPrice(ReptBindingModel model);
        List<StorageLoadViewModel> GetStorageLoad();
        void SaveStorageLoad(ReptBindingModel model);
        List<CustomerOrdersViewModel> GetCustomerOrders(ReptBindingModel model);
        void SaveCustomerOrders(ReptBindingModel model);
    }
}
