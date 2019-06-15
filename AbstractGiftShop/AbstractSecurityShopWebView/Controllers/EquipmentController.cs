using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractSecurityShopWebView.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            _service.AddElement(new EquipmentBindingModel
            {
                EquipmentName = Request["EquipmentName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new EquipmentBindingModel
            {
                Id = id,
                EquipmentName = viewModel.EquipmentName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new EquipmentBindingModel
            {
                Id = int.Parse(Request["Id"]),
                EquipmentName = Request["EquipmentName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}