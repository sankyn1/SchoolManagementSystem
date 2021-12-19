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
    public class StudentMastersController : Controller
    {
        private InstituteManagementEntities1 db = new InstituteManagementEntities1();

        // GET: StudentMasters
        public ActionResult Index()
        {
            var studentMasters = db.StudentMasters.Include(s => s.city).Include(s => s.country).Include(s => s.state);
            return View(studentMasters.ToList());
        }

        // GET: StudentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // GET: StudentMasters/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.cities, "id", "name");
            ViewBag.CountryId = new SelectList(db.countries, "id", "sortname");
            ViewBag.StateId = new SelectList(db.states, "id", "name");
            return View();
        }

        // POST: StudentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Address,CountryId,StateId,CityId,Pin")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.StudentMasters.Add(studentMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.cities, "id", "name", studentMaster.CityId);
            ViewBag.CountryId = new SelectList(db.countries, "id", "sortname", studentMaster.CountryId);
            ViewBag.StateId = new SelectList(db.states, "id", "name", studentMaster.StateId);
            return View(studentMaster);
        }

        // GET: StudentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.cities, "id", "name", studentMaster.CityId);
            ViewBag.CountryId = new SelectList(db.countries, "id", "sortname", studentMaster.CountryId);
            ViewBag.StateId = new SelectList(db.states, "id", "name", studentMaster.StateId);
            return View(studentMaster);
        }

        // POST: StudentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Address,CountryId,StateId,CityId,Pin")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.cities, "id", "name", studentMaster.CityId);
            ViewBag.CountryId = new SelectList(db.countries, "id", "sortname", studentMaster.CountryId);
            ViewBag.StateId = new SelectList(db.states, "id", "name", studentMaster.StateId);
            return View(studentMaster);
        }

        // GET: StudentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // POST: StudentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            db.StudentMasters.Remove(studentMaster);
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
