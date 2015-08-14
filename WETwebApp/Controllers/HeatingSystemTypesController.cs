using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WETwebApp.DAL;
using WETwebApp.Models;

namespace WETwebApp.Controllers
{
    public class HeatingSystemTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: HeatingSystemTypes
        public ActionResult Index()
        {
            return View(db.HeatingSystemTypes.ToList());
        }

        // GET: HeatingSystemTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeatingSystemType heatingSystemType = db.HeatingSystemTypes.Find(id);
            if (heatingSystemType == null)
            {
                return HttpNotFound();
            }
            return View(heatingSystemType);
        }

        // GET: HeatingSystemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeatingSystemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeatingSystemTypeID,Type")] HeatingSystemType heatingSystemType)
        {
            if (ModelState.IsValid)
            {
                db.HeatingSystemTypes.Add(heatingSystemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heatingSystemType);
        }

        // GET: HeatingSystemTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeatingSystemType heatingSystemType = db.HeatingSystemTypes.Find(id);
            if (heatingSystemType == null)
            {
                return HttpNotFound();
            }
            return View(heatingSystemType);
        }

        // POST: HeatingSystemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeatingSystemTypeID,Type")] HeatingSystemType heatingSystemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heatingSystemType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heatingSystemType);
        }

        // GET: HeatingSystemTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeatingSystemType heatingSystemType = db.HeatingSystemTypes.Find(id);
            if (heatingSystemType == null)
            {
                return HttpNotFound();
            }
            return View(heatingSystemType);
        }

        // POST: HeatingSystemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeatingSystemType heatingSystemType = db.HeatingSystemTypes.Find(id);
            db.HeatingSystemTypes.Remove(heatingSystemType);
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
