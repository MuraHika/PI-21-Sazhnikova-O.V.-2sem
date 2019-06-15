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
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<OrderViewModel> GetList();
        [CustomMethod("Метод получения списка работников")]
        List<OrderViewModel> GetFreeOrders();
        [CustomMethod("Метод принятия заказа")]
        void AcceptedOrder(OrderBindingModel model);
        [CustomMethod("Метод обработки заказа")]
        void Processed(OrderBindingModel model);
        [CustomMethod("Метод готовности заказа")]
        void OrderReady(OrderBindingModel model);
        [CustomMethod("Метод оплаты заказа")]
        void OrderPaid(OrderBindingModel model);
        [CustomMethod("Метод пополнения хранилища")]
        void PutEquipmentOnStorage(StorageEquipmentBindingModel model);
    }
}
