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
    public class ReptController : ApiController
    {
        private readonly IReptService _service;

        public ReptController(IReptService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStorageLoad()
        {
            var list = _service.GetStorageLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerOrders(ReptBindingModel model)
        {
            var list = _service.GetCustomerOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveTechnicsPrice(ReptBindingModel model)
        {
            _service.SaveTechnicsPrice(model);
        }

        [HttpPost]
        public void SaveStorageLoad(ReptBindingModel model)
        {
            _service.SaveStorageLoad(model);
        }

        [HttpPost]
        public void SaveCustomerOrders(ReptBindingModel model)
        {
            _service.SaveCustomerOrders(model);
        }
    }
}
