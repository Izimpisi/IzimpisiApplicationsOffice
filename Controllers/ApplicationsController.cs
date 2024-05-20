using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            var userId = User.Identity.GetUserId();

            var applications = db.Application
                              .Include(a => a.ApplicationUser)
                              .Where(a => a.ApplicationUserId == userId)
                              .ToList();
            return View(applications);
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
        public ActionResult Create([Bind(Include = "Id,Program,PersonalStatement")] Application application)
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

            application.ApplicationDate = DateTime.Now;
            application.Status = Application.Statuses.Pending;
            application.ApplicationUserId = userId;
            db.Application.Add(application);
            db.SaveChanges();
            return RedirectToAction("Index", "Applications");
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
        public ActionResult Edit([Bind(Include = "Id,Program,PersonalStatement,ApplicationDate,Status,ApplicationUserId")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", application.ApplicationUserId);
            return View(application);
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
