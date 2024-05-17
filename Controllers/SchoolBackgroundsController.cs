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

namespace IzimpisiApplicationsOffice.Controllers
{
    public class SchoolBackgroundsController : Controller
    {
        private DbContextIAO db = new DbContextIAO();

        // GET: SchoolBackgrounds
        public ActionResult Index()
        {
            return View(db.SchoolBackgrounds.ToList());
        }

        // GET: SchoolBackgrounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolBackground schoolBackground = db.SchoolBackgrounds.Find(id);
            if (schoolBackground == null)
            {
                return HttpNotFound();
            }
            return View(schoolBackground);
        }

        // GET: SchoolBackgrounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolBackgrounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SchoolName,YearCompleted,ApplicationUserId")] SchoolBackground schoolBackground)
        {
            if (ModelState.IsValid)
            {
                db.SchoolBackgrounds.Add(schoolBackground);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolBackground);
        }

        // GET: SchoolBackgrounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolBackground schoolBackground = db.SchoolBackgrounds.Find(id);
            if (schoolBackground == null)
            {
                return HttpNotFound();
            }
            return View(schoolBackground);
        }

        // POST: SchoolBackgrounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchoolName,YearCompleted,ApplicationUserId")] SchoolBackground schoolBackground)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolBackground).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolBackground);
        }

        // GET: SchoolBackgrounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolBackground schoolBackground = db.SchoolBackgrounds.Find(id);
            if (schoolBackground == null)
            {
                return HttpNotFound();
            }
            return View(schoolBackground);
        }

        // POST: SchoolBackgrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolBackground schoolBackground = db.SchoolBackgrounds.Find(id);
            db.SchoolBackgrounds.Remove(schoolBackground);
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
