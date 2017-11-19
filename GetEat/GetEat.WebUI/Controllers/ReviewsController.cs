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
using Microsoft.AspNet.Identity;

namespace GetEat.WebUI.Controllers
{
    public class ReviewsController : Controller
    {
        private GetEatContext db = new GetEatContext();
        private readonly IAccountService accountService;

        public ReviewsController()
        {
            accountService = new AccountService(new DataUnitOfWork());
        }

        // GET: Reviews
        public ActionResult Index(int id)
        {
            var reviews = db.Reviews.Where(x => x.RestourantId == id).Include(r => r.CommentatorUserProfile);

            var vm = reviews.Select(x => new ReviewViewModel()
            {
                Commentator = x.CommentatorUserProfile.ForeName + " " + x.CommentatorUserProfile.SurName,
                Comment = x.Comment,
                Score = x.Score,
                WrittenDate = x.CreatedDate
            }).OrderByDescending(x=>x.WrittenDate).ToList();

            return PartialView(vm);
        }


        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    Comment = model.Comment,
                    Score = model.Score,
                    RestourantId = model.RestourantId,
                    CommentatorUserProfileId = accountService.GetUserProfileId(User.Identity.GetUserId()),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToActionPermanent("Details", "Search", new { id = model.RestourantId });
            }

            return PartialView(model);
        }


        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
