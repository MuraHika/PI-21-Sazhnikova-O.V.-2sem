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
    [CustomInterface("Интерфейс для работы с оборудованием")]

    public interface IEquipmentService
    {
        [CustomMethod("Метод получения списка оборудования")]
        List<EquipmentViewModel> GetList();
        [CustomMethod("Метод получения оборудования по id")]
        EquipmentViewModel GetElement(int id);
        [CustomMethod("Метод добавления оборудования")]
        void AddElement(EquipmentBindingModel model);
        [CustomMethod("Метод изменения данных по оборудованию")]
        void UpdElement(EquipmentBindingModel model);
        [CustomMethod("Метод удаления оборудования")]
        void DelElement(int id);
    }
}
