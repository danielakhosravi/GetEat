using GetEat.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetEat.WebUI.Areas.Companies.Controllers
{
    [Authorize(Roles = RoleNames.Customer)]
    public class DashboardController : Controller
    {
        // GET: Companies/Dashboard
        public ActionResult Index()
        {
            var vm = new List<RestourantViewModel>();
            return View(vm);
        }

        // GET: Companies/Dashboard/Details/5
        public ActionResult Details(int id)
        {
            var vm = new RestourantViewModel();
            return View(vm);
        }

        // GET: Companies/Dashboard/Create
        public ActionResult Create()
        {
            var vm = new RestourantViewModel();
            return View(vm);
        }

        // POST: Companies/Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = new RestourantViewModel();
            return View(vm);
        }

        // POST: Companies/Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = new RestourantViewModel();
            return View(vm);
        }

        // POST: Companies/Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
