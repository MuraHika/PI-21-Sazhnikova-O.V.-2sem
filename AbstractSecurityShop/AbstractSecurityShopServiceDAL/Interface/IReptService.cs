using AbstractSecurityShopServiceDAL.Attributies;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReptService
    {
        [CustomMethod("Метод сохранения прайса по технике")]
        void SaveTechnicsPrice(ReptBindingModel model);
        [CustomMethod("Метод получения загруженности хранилища")]
        List<StorageLoadViewModel> GetStorageLoad();
        [CustomMethod("Метод сохранения загруженности хранилища")]
        void SaveStorageLoad(ReptBindingModel model);
        [CustomMethod("Метод получения списка заказчиков и их заказов")]
        List<CustomerOrdersViewModel> GetCustomerOrders(ReptBindingModel model);
        [CustomMethod("Метод сохранения заказчиков и их заказов")]
        void SaveCustomerOrders(ReptBindingModel model);
    }
}
