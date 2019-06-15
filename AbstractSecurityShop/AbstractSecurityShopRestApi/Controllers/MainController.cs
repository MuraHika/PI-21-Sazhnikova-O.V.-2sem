using AbstractSecurityShopRestApi.Services;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AbstractSecurityShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;
        private readonly IWorkerService _serviceWorker;

        public MainController(IMainService service, IWorkerService serviceWorker)
        {
            _service = service;
            _serviceWorker = serviceWorker;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            _service.AcceptedOrder(model);
        }

        [HttpPost]
        public void TakeOrderInWork(OrderBindingModel model)
        {
            _service.Processed(model);
        }

        [HttpPost]
        public void FinishOrder(OrderBindingModel model)
        {
            _service.OrderReady(model);
        }

        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _service.OrderPaid(model);
        }

        [HttpPost]
        public void PutComponentOnStock(StorageEquipmentBindingModel model)
        {
            _service.PutEquipmentOnStorage(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<OrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                WorkerViewModel impl = _serviceWorker.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkWorker(_service, _serviceWorker, impl.Id, order.Id);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}
