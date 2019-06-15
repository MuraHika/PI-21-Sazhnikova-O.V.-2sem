using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
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

        public MainController(IMainService service)
        {
            _service = service;
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
    }
}
