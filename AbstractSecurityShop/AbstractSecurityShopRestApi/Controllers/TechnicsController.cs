﻿using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AbstractSecurityShopRestApi.Controllers
{
    public class TechnicsController : ApiController
    {
        private readonly ITechnicsService _service;
        public TechnicsController(ITechnicsService service)
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
        public void AddElement(TechnicsBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(TechnicsBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(TechnicsBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
