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
    public class CourseMastersController : Controller
    {
        private InstituteManagementEntities1 db = new InstituteManagementEntities1();

        // GET: CourseMasters
        public ActionResult Index()
        {
            return View(db.CourseMasters.ToList());
        }

        // GET: CourseMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaster courseMaster = db.CourseMasters.Find(id);
            if (courseMaster == null)
            {
                return HttpNotFound();
            }
            return View(courseMaster);
        }

        // GET: CourseMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] CourseMaster courseMaster)
        {
            if (ModelState.IsValid)
            {
                db.CourseMasters.Add(courseMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseMaster);
        }

        // GET: CourseMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaster courseMaster = db.CourseMasters.Find(id);
            if (courseMaster == null)
            {
                return HttpNotFound();
            }
            return View(courseMaster);
        }

        // POST: CourseMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CourseMaster courseMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseMaster);
        }

        // GET: CourseMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaster courseMaster = db.CourseMasters.Find(id);
            if (courseMaster == null)
            {
                return HttpNotFound();
            }
            return View(courseMaster);
        }

        // POST: CourseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseMaster courseMaster = db.CourseMasters.Find(id);
            db.CourseMasters.Remove(courseMaster);
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
