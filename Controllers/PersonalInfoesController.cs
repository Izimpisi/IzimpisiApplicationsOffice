using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IzimpisiApplicationsOffice.Models;
using IzimpisiApplicationsOffice.Models.UserFields;
using Microsoft.AspNet.Identity;

namespace IzimpisiApplicationsOffice.Controllers
{
    public class PersonalInfoesController : Controller
    {
        private DbContextIAO db = new DbContextIAO();

        // GET: PersonalInfoes
        public ActionResult Index()
        {
            return View(db.PersonalInfo.ToList());
        } 

        // GET: PersonalInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdentityNumber,Title,FirstName,LastName,Age")] PersonalInfo personalInfo)
        {

            // Retrieve the current user's ID
            string userId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // If the user is not logged in, redirect to the register page
                return RedirectToAction("Register", "Account");
            }

            if (ModelState.IsValid)
            {
                personalInfo.ApplicationUserId = userId;
                db.PersonalInfo.Add(personalInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }

        // GET: PersonalInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdentityNumber,Title,FirstName,LastName,Age,ApplicationUserId")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SchoolBackgrounds/Create");
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            db.PersonalInfo.Remove(personalInfo);
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
