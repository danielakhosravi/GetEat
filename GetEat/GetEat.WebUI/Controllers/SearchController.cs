using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModel;
using DomainModel.Entities;

namespace GetEat.WebUI.Controllers
{
    public class SearchController : Controller
    {
        private GetEatContext db = new GetEatContext();

        // GET: Restourants
        public ActionResult Index()
        {
            var restourants = db.Restourants.Include(r => r.Address).Include(r => r.Organisation);
            return View(restourants.ToList());
        }

        // GET: Restourants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restourant restourant = db.Restourants.Find(id);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
