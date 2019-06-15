using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractSecurityShopWebView.Controllers
{
    public class TechnicsController : Controller
    {
        private readonly ITechnicsService _service;
        private readonly IEquipmentService _eqService;

        public TechnicsController(ITechnicsService service, IEquipmentService eqService)
        {
            _service = service;
            _eqService = eqService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            if (Session["Technics"] == null)
            {
                var candy = new TechnicsBindingModel();
                candy.TechnicsEquipment = new List<TechnicsEquipmentBindingModel>();
                Session["Technics"] = candy;
            }
            return View((TechnicsBindingModel)Session["Technics"]);
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var technic = (TechnicsBindingModel)Session["Technics"];

            technic.TechnicsName = Request["TechnicsName"];
            technic.Price = Convert.ToDecimal(Request["Price"]);

            _service.AddElement(technic);

            Session.Remove("Technics");

            return RedirectToAction("Index");
        }

        public ActionResult AddEquipment()
        {
            var equipment = new SelectList(_eqService.GetList(), "Id", "EquipmentName");
            ViewBag.Equipments = equipment;
            return View();
        }

        [HttpPost]
        public ActionResult AddEquipmentPost()
        {
            var technic = (TechnicsBindingModel)Session["Technics"];
            var equipment = new TechnicsEquipmentBindingModel
            {
                TechnicsId = technic.Id,
                EquipmentId = int.Parse(Request["EquipmentId"]),
                Count = int.Parse(Request["Count"])
            };
            technic.TechnicsEquipment.Add(equipment);
            Session["Technics"] = technic;
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new TechnicsBindingModel
            {
                Id = id,
                TechnicsName = viewModel.TechnicsName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new TechnicsBindingModel
            {
                Id = int.Parse(Request["Id"]),
                TechnicsName = Request["TechnicsName"]
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