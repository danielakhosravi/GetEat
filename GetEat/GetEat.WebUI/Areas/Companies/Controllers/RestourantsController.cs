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
        public ActionResult Index(int organisationId)
        {
            ViewBag.OrganisationId = organisationId;

            var restourants = db.Restourants.Where(x => x.OrganisationId == organisationId).Include(r => r.Address).Include(r => r.Organisation).ToList();
            return View(restourants);
        }

        // GET: Companies/Restourants/Details/5
        public ActionResult Details(int restourantId)
        {
            //id is restourant id
            Restourant restourant = db.Restourants.Find(restourantId);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        // GET: Companies/Restourants/Create
        public ActionResult Create(int organisationId)
        {
            var restourant = new RestourantViewModel { OrganisationId = organisationId };
            ViewBag.KitchenId = new SelectList(db.Kitchens, "Id", "Name", restourant.KitchenId);

            return View(restourant);
        }

        // POST: Companies/Restourants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestourantViewModel restourant)
        {
            ViewBag.OrganisationId = restourant.OrganisationId;
            if (ModelState.IsValid)
            {
                CreateRestourant(restourant);
                return RedirectToAction("Index", new { OrganisationId = restourant.OrganisationId });
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country", restourant.AddressId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name", restourant.OrganisationId);
            return View(restourant);
        }

        private void CreateRestourant(RestourantViewModel restourant)
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
                Name = restourant.Name,
                Description = restourant.Description,
                AddressId = address.Id,
                OrganisationId = restourant.OrganisationId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                KitchenId = 2,
                PicGuidId = Guid.NewGuid().ToString()
            };
            db.Restourants.Add(newResourant);
            db.SaveChanges();
        }

        // GET: Companies/Restourants/Edit/5
        public ActionResult Edit(int? restourantId)
        {
            // id is
            if (restourantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restourant restourant = db.Restourants.Find(restourantId);
            var mv = MapRestourant(restourant);

            ViewBag.KitchenId = new SelectList(db.Kitchens, "Id", "Name", restourant.KitchenId);

            return View(mv);
        }

        private RestourantViewModel MapRestourant(Restourant restourant)
        {
            var model = new RestourantViewModel
            {
                Id = restourant.Id,
                Description = restourant.Description,
                AddressId = restourant.AddressId,
                Address = new AddressViewModel()
                {
                    City = restourant.Address.City,
                    Country = restourant.Address.Country,
                    Neighborhood = restourant.Address.Neighborhood,
                    Number = restourant.Address.Number,
                    Latitude = restourant.Address.Latitude,
                    Longitude = restourant.Address.Longitude,
                    Street = restourant.Address.Street,
                },
                KitchenId = restourant.KitchenId,
                Name = restourant.Name,
                PicGuidId = restourant.PicGuidId,
                OrganisationId = restourant.OrganisationId,
                Reviews = restourant.Reviews.Select(x => new ReviewViewModel()
                {
                    Comment = x.Comment,
                    Commentator = x.CommentatorUserProfile.ForeName + " " + x.CommentatorUserProfile.SurName,
                    Score = x.Score
                }).ToList()
            };

            return model;
        }

        // POST: Companies/Restourants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestourantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Restourant restourant = MapViewModel(model);

                db.Entry(restourant).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", new { organisationId = model.OrganisationId });
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Country", model.AddressId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "Id", "Name", model.OrganisationId);
            ViewBag.KitchenId = new SelectList(db.Kitchens, "Id", "Name", model.KitchenId);
            return View(model);
        }

        private Restourant MapViewModel(RestourantViewModel model)
        {
            Restourant restourant = db.Restourants.Find(model.Id);
            restourant.KitchenId = model.KitchenId;

            restourant.Address.Street = model.Address.Street;
            restourant.Address.City = model.Address.Street;
            restourant.Address.Country = model.Address.Street;
            restourant.Address.Neighborhood = model.Address.Street;
            restourant.Address.Latitude = model.Address.Street;
            restourant.Address.Longitude = model.Address.Street;

            restourant.Name = model.Name;
            restourant.Description = model.Description;
            restourant.KitchenId = model.KitchenId;
            restourant.UpdatedDate = DateTime.Now;
            return restourant;
        }

        // GET: Companies/Restourants/Delete/5
        public ActionResult Delete(int? restourantId)
        {
            if (restourantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restourant restourant = db.Restourants.Find(restourantId);
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
            return RedirectToAction("Index", new { organisationId = restourant.OrganisationId });
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
