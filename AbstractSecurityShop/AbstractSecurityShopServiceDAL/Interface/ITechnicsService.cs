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
    [CustomInterface("Интерфейс для работы с техникой")]
    public interface ITechnicsService
    {
        [CustomMethod("Метод получения списка техники")]
        List<TechnicsViewModel> GetList();
        [CustomMethod("Метод получения техники по id ")]
        TechnicsViewModel GetElement(int id);
        [CustomMethod("Метод добавления техники")]
        void AddElement(TechnicsBindingModel model);
        [CustomMethod("Метод изменения данных по технике")]
        void UpdElement(TechnicsBindingModel model);
        [CustomMethod("Метод удаления техники")]
        void DelElement(int id);
    }
}
