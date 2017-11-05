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

namespace GetEat.WebUI.Areas.Companies.Controllers
{
    public class OrganisationsController : BaseCompaniesController
    {
        private GetEatContext db = new GetEatContext();


        // GET: Companies/Organisations/Details/5
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


        // GET: Companies/Organisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);

            var vm = new OrganisationViewModel
            {
                Id = organisation.Id,
                Name = organisation.Name,
                Phone = organisation.Phone,
                Fax = organisation.Fax
            };
            if (organisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId", organisation.OwnerProfileId);
            return View(vm);
        }

        // POST: Companies/Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrganisationViewModel organisation)
        {
            if (ModelState.IsValid)
            {
                Organisation oldOrganisation = db.Organisations.Find(organisation.Id);
                oldOrganisation.Name = organisation.Name;
                oldOrganisation.Phone = organisation.Phone;
                oldOrganisation.Fax = organisation.Fax;
                oldOrganisation.UpdatedDate = DateTime.Now;


                db.Entry(oldOrganisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = oldOrganisation.Id });
            }
            ViewBag.OwnerProfileId = new SelectList(db.UserProfiles, "Id", "AspNetUserId", organisation.OwnerProfileId);
            return View(organisation);
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
