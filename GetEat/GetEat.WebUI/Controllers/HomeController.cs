using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetEat.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetEatContext getEatContext;
        public HomeController()
        {
            getEatContext = new GetEatContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string city, string cuisine)
        {
            return RedirectToAction("Index", "Search", new { area = "" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetKitchens()
        {
            return Json(getEatContext.Kitchens.Select(x => x.Name).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}