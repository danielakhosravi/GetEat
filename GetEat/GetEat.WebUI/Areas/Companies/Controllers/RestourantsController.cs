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
using GetEat.WebUI.Models;
using Domain;

namespace GetEat.WebUI.Areas.Companies.Controllers
{

    public class RestourantsController : BaseCompaniesController
    {
        private GetEatContext db = new GetEatContext();
        private readonly IAccountService accountService;

        public RestourantsController()
        {
            accountService = new AccountService(new DataUnitOfWork());
        }

        // GET: Companies/Restourants
        public ActionResult Index(int id)
        {
            var restourants = db.Restourants.Include(r => r.Address).Include(r => r.Organisation);
            return View(restourants.ToList());
        }

        // GET: Companies/Restourants/Details/5
        public ActionResult Details(int id)
        {
            Restourant restourant = db.Restourants.Find(id);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        // GET: Companies/Restourants/Create
        public ActionResult Create(int id)
        {
            return View(new RestourantViewModel { OrganisationId = id });
        }

        // POST: Companies/Restourants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestourantViewModel restourant)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Country = restourant.Address.Country,
                    City = restourant.Address.City,
                    Neighborhood = restourant.Address.Neighborhood,
                    Street = restourant.Address.Street,
                    Number = restourant.Address.Number,
                    Latitude = restourant.Address.Latitude,
                    Longitude = restourant.Address.Longitude,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                db.Addresses.Add(address);
                db.SaveChanges();
                db.Entry<Address>(address).Reload();

                var newResourant = new Restourant
                {
                    AddressId = address.Id,
                    OrganisationId = restourant.OrganisationId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                db.Restourants.Add(newResourant);
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
