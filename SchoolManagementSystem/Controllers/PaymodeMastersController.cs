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
    public class PaymodeMastersController : Controller
    {
        private InstituteManagementEntities1 db = new InstituteManagementEntities1();

        // GET: PaymodeMasters
        public ActionResult Index()
        {
            return View(db.PaymodeMasters.ToList());
        }

        // GET: PaymodeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymodeMaster paymodeMaster = db.PaymodeMasters.Find(id);
            if (paymodeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymodeMaster);
        }

        // GET: PaymodeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymodeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PaymodeMaster paymodeMaster)
        {
            if (ModelState.IsValid)
            {
                db.PaymodeMasters.Add(paymodeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymodeMaster);
        }

        // GET: PaymodeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymodeMaster paymodeMaster = db.PaymodeMasters.Find(id);
            if (paymodeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymodeMaster);
        }

        // POST: PaymodeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PaymodeMaster paymodeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymodeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymodeMaster);
        }

        // GET: PaymodeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymodeMaster paymodeMaster = db.PaymodeMasters.Find(id);
            if (paymodeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymodeMaster);
        }

        // POST: PaymodeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymodeMaster paymodeMaster = db.PaymodeMasters.Find(id);
            db.PaymodeMasters.Remove(paymodeMaster);
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
