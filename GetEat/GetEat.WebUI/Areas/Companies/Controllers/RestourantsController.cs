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


namespace GetEat.WebUI.Areas.Companies.Controllers
{
    
    public class RestourantsController : BaseCompaniesController
    {
        private GetEatContext db = new GetEatContext();

        // GET: Companies/Restourants
        public ActionResult Index()
        {
            var restourants = db.Restourants.Include(r => r.Address).Include(r => r.Organisation);
            return View(restourants.ToList());
        }

        // GET: Companies/Restourants/Details/5
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

        // GET: Companies/Restourants/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country");
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name");
            return View();
        }

        // POST: Companies/Restourants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,OrganisationId,AddressId,PicGuidId,CreatedDate,UpdatedDate")] Restourant restourant)
        {
            if (ModelState.IsValid)
            {
                db.Restourants.Add(restourant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country", restourant.AddressId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name", restourant.OrganisationId);
            return View(restourant);
        }

        // GET: Companies/Restourants/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country", restourant.AddressId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name", restourant.OrganisationId);
            return View(restourant);
        }

        // POST: Companies/Restourants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,OrganisationId,AddressId,PicGuidId,CreatedDate,UpdatedDate")] Restourant restourant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restourant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country", restourant.AddressId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name", restourant.OrganisationId);
            return View(restourant);
        }

        // GET: Companies/Restourants/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Companies/Restourants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restourant restourant = db.Restourants.Find(id);
            db.Restourants.Remove(restourant);
            db.SaveChanges();
            return RedirectToAction("Index");
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
