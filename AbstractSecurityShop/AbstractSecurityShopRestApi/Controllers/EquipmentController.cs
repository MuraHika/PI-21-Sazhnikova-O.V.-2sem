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
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(EquipmentBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(EquipmentBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(EquipmentBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
