using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteManagement.Models;

namespace InstituteManagement.Controllers
{
    public class UniversityMastersController : Controller
    {
        private InstituteManagementEntities1 db = new InstituteManagementEntities1();

        // GET: UniversityMasters
        public ActionResult Index()
        {
            return View(db.UniversityMasters.ToList());
        }

        // GET: UniversityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityMaster universityMaster = db.UniversityMasters.Find(id);
            if (universityMaster == null)
            {
                return HttpNotFound();
            }
            return View(universityMaster);
        }

        // GET: UniversityMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] UniversityMaster universityMaster)
        {
            if (ModelState.IsValid)
            {
                db.UniversityMasters.Add(universityMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universityMaster);
        }

        // GET: UniversityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityMaster universityMaster = db.UniversityMasters.Find(id);
            if (universityMaster == null)
            {
                return HttpNotFound();
            }
            return View(universityMaster);
        }

        // POST: UniversityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] UniversityMaster universityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universityMaster);
        }

        // GET: UniversityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityMaster universityMaster = db.UniversityMasters.Find(id);
            if (universityMaster == null)
            {
                return HttpNotFound();
            }
            return View(universityMaster);
        }

        // POST: UniversityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniversityMaster universityMaster = db.UniversityMasters.Find(id);
            db.UniversityMasters.Remove(universityMaster);
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
