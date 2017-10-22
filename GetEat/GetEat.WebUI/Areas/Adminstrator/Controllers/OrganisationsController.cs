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

namespace GetEat.WebUI.Areas.Adminstrator.Controllers
{
    public class OrganisationsController : Controller
    {
        private GetEatContext db = new GetEatContext();

        // GET: Adminstrator/Organisations
        public ActionResult Index()
        {
            var organisations = db.Organisations.Include(o => o.OwnerProfile);
            return View(organisations.ToList());
        }

        // GET: Adminstrator/Organisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // GET: Adminstrator/Organisations/Create
        public ActionResult Create()
        {
            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId");
            return View();
        }

        // POST: Adminstrator/Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerProfileId,Name,Phone,Fax,CreatedDate,UpdatedDate")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Organisations.Add(organisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId", organisation.OwnerProfileId);
            return View(organisation);
        }

        // GET: Adminstrator/Organisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId", organisation.OwnerProfileId);
            return View(organisation);
        }

        // POST: Adminstrator/Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerProfileId,Name,Phone,Fax,CreatedDate,UpdatedDate")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId", organisation.OwnerProfileId);
            return View(organisation);
        }

        // GET: Adminstrator/Organisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Adminstrator/Organisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            db.Organisations.Remove(organisation);
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
