using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractSecurityShopWebView.Controllers
{
    public class MainController : Controller
    {
        private readonly IMainService _service;
        private readonly ITechnicsService _tecService;
        private readonly ICustomerService _cusService;

        public MainController(IMainService service, ITechnicsService tecService, ICustomerService cusService)
        {
            _service = service;
            _tecService = tecService;
            _cusService = cusService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            var technic = new SelectList(_tecService.GetList(), "Id", "TechnicsName");
            var customer = new SelectList(_cusService.GetList(), "Id", "CustomerFIO");
            ViewBag.Technics = technic;
            ViewBag.Customers = customer;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var customerId = int.Parse(Request["CustomerId"]);
            var technicsId = int.Parse(Request["TechnicsId"]);
            var count = int.Parse(Request["Count"]);
            var sum = CalcSum(technicsId, count);

            _service.AcceptedOrder(new OrderBindingModel
            {
                CustomerId = customerId,
                TechnicsId = technicsId,
                Count = count,
                Sum = sum
            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int Id, int Count)
        {
            TechnicsViewModel technics = _tecService.GetElement(Id);
            return Count * technics.Price;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processed":
                        _service.Processed(new OrderBindingModel { Id = id });
                        break;
                    case "Ready":
                        _service.OrderReady(new OrderBindingModel { Id = id });
                        break;
                    case "Paid":
                        _service.OrderPaid(new OrderBindingModel { Id = id });
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}