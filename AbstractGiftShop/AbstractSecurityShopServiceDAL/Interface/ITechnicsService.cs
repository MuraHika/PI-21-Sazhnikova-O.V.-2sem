using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    public interface ITechnicsService
    {
        List<TechnicsViewModel> GetList();
        TechnicsViewModel GetElement(int id);
        void AddElement(TechnicsBindingModel model);
        void UpdElement(TechnicsBindingModel model);
        void DelElement(int id);
    }
}
