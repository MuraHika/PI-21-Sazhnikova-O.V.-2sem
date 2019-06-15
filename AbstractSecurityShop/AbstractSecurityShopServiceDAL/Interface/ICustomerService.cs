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
    [CustomInterface("Интерфейс для работы с заказчиками")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка заказчиков")]
        List<CustomerViewModel> GetList();
        [CustomMethod("Метод получения заказчика по id")]
        CustomerViewModel GetElement(int id);
        [CustomMethod("Метод добавления заказчика")]
        void AddElement(CustomerBindingModel model);
        [CustomMethod("Метод изменения данных по заказчику")]
        void UpdElement(CustomerBindingModel model);
        [CustomMethod("Метод удаления заказчика")]
        void DelElement(int id);
    }

}
