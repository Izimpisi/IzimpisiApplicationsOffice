using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IzimpisiApplicationsOffice.Models;
using IzimpisiApplicationsOffice.Models.Applications;
using IzimpisiApplicationsOffice.Models.UserFields;
using Microsoft.AspNet.Identity;

namespace IzimpisiApplicationsOffice.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applications
        public ActionResult Index()
        {
            // Get the ID of the logged-in user
            var userEmail = User.Identity.Name;
            var userId = User.Identity.GetUserId();

            if(userEmail == "admin@gmail.com")
            {
                var applications = db.Application
                              .Include(a => a.ApplicationUser)
                              .ToList();
                return View(applications);
            } else
            {
                var applications = db.Application
                    .Include(a => a.ApplicationUser)
                    .Where(a => a.ApplicationUserId == userId)
                    .ToList();

                return View(applications);
            }
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Program,PersonalStatement, StartTerm")] Application application)
        {
            //if (ModelState.IsValid)
            //{
            // Retrieve the current user's ID
            string userId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // If the user is not logged in, redirect to the register page
                return RedirectToAction("Register", "Account");
            }
            var applications = db.Application.Include(a => a.Course).ToList();
            foreach (var app in applications)
            {
                if (app.Course == null)
                {
                    application.Status = Application.Statuses.Incomplete;
                } else
                {
                    application.Status = Application.Statuses.Pending;
                }
            }

            application.ApplicationDate = DateTime.Now;
            application.ApplicationUserId = userId;
            db.Application.Add(application);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or handle the validation error
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                // Optionally rethrow the exception or handle it as needed
                throw;
            }
                return RedirectToAction("Index", "Courses");
            //}

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", application.ApplicationUserId);
            //return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", application.ApplicationUserId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Program,PersonalStatement, NeedResidence")] Application application)
        {

            // Retrieve the current user's ID
            string userId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // If the user is not logged in, redirect to the register page
                return RedirectToAction("Register", "Account");
            }

            var applications = db.Application.Include(a => a.Course).ToList();
            foreach (var app in applications)
            {
                if (app.Course == null)
                {
                    application.Status = Application.Statuses.Incomplete;
                }
                else
                {
                    application.Status = Application.Statuses.Pending;
                }
            }

                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Applications");
        }

        public ActionResult EditAdmin(int? id)
        {
            var userEmail = User.Identity.Name;

            if (userEmail != "admin@gmail.com")
            {
                RedirectToAction("Index", "Applications");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", application.ApplicationUserId);
            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin([Bind(Include = "Status")] Application application)
        {
            // Retrieve the current user's ID
            string userId = User.Identity.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                // If the user is not logged in, redirect to the register page
                return RedirectToAction("Register", "Account");
            }
            if (userId != "e57af288-0e37-4e6c-9efe-76c49a8eacd3")
            {
                RedirectToAction("Index", "Applications");
            }

            var applications = db.Application.Include(a => a.Course).ToList();
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Applications");
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Application.Find(id);
            db.Application.Remove(application);
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
