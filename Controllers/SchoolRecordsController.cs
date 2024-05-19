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
    public class SchoolRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolRecords
        public ActionResult Index()
        {
            var schoolRecords = db.SchoolRecords.Include(s => s.SchoolBackground);
            return View(schoolRecords.ToList());
        }

        // GET: SchoolRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolRecords schoolRecords = db.SchoolRecords.Find(id);
            if (schoolRecords == null)
            {
                return HttpNotFound();
            }
            return View(schoolRecords);
        }

        // GET: SchoolRecords/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.SchoolBackgrounds, "ApplicationUserId", "SchoolName");
            return View();
        }

        // POST: SchoolRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectName,Score")] SchoolRecords schoolRecords)
        {

            // Retrieve the current user's ID
            string userId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // If the user is not logged in, redirect to the register page
                return RedirectToAction("Register", "Account");
            }
                schoolRecords.level = schoolRecords.GetAPSLevel();
                schoolRecords.ApplicationUserId = userId;
                db.SchoolRecords.Add(schoolRecords);
                db.SaveChanges();
                return RedirectToAction("Index", "SchoolRecords");
        }

        // GET: SchoolRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolRecords schoolRecords = db.SchoolRecords.Find(id);
            if (schoolRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.SchoolBackgrounds, "ApplicationUserId", "SchoolName", schoolRecords.ApplicationUserId);
            return View(schoolRecords);
        }

        // POST: SchoolRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectName,Score,level,ApplicationUserId")] SchoolRecords schoolRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.SchoolBackgrounds, "ApplicationUserId", "SchoolName", schoolRecords.ApplicationUserId);
            return View(schoolRecords);
        }

        // GET: SchoolRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolRecords schoolRecords = db.SchoolRecords.Find(id);
            if (schoolRecords == null)
            {
                return HttpNotFound();
            }
            return View(schoolRecords);
        }

        // POST: SchoolRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolRecords schoolRecords = db.SchoolRecords.Find(id);
            db.SchoolRecords.Remove(schoolRecords);
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
