using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    public interface IMainService
    {
        List<OrderViewModel> GetList();
        void AcceptedOrder(OrderBindingModel model);
        void Processed(OrderBindingModel model);
        void OrderReady(OrderBindingModel model);
        void OrderPaid(OrderBindingModel model);
        void PutEquipmentOnStorage(StorageEquipmentBindingModel model);
    }
}
