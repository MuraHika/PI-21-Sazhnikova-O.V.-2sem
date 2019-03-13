using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    public interface IEquipmentService
    {
        List<EquipmentViewModel> GetList();
        EquipmentViewModel GetElement(int id);
        void AddElement(EquipmentBindingModel model);
        void UpdElement(EquipmentBindingModel model);
        void DelElement(int id);
    }
}
