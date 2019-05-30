using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Interface
{
    public interface IWorkerService
    {
        List<WorkerViewModel> GetList();
        WorkerViewModel GetElement(int id);
        void AddElement(WorkerBindingModel model);
        void UpdElement(WorkerBindingModel model);
        void DelElement(int id);
        WorkerViewModel GetFreeWorker();
    }
}
