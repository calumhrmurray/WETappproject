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
    public class TelevisionSupplierTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: TelevisionSupplierTypes
        public ActionResult Index()
        {
            return View(db.TelevisionSupplierTypes.ToList());
        }

        // GET: TelevisionSupplierTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelevisionSupplierType televisionSupplierType = db.TelevisionSupplierTypes.Find(id);
            if (televisionSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(televisionSupplierType);
        }

        // GET: TelevisionSupplierTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TelevisionSupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelevisionSupplierTypeID,Type")] TelevisionSupplierType televisionSupplierType)
        {
            if (ModelState.IsValid)
            {
                db.TelevisionSupplierTypes.Add(televisionSupplierType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(televisionSupplierType);
        }

        // GET: TelevisionSupplierTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelevisionSupplierType televisionSupplierType = db.TelevisionSupplierTypes.Find(id);
            if (televisionSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(televisionSupplierType);
        }

        // POST: TelevisionSupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelevisionSupplierTypeID,Type")] TelevisionSupplierType televisionSupplierType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(televisionSupplierType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(televisionSupplierType);
        }

        // GET: TelevisionSupplierTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelevisionSupplierType televisionSupplierType = db.TelevisionSupplierTypes.Find(id);
            if (televisionSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(televisionSupplierType);
        }

        // POST: TelevisionSupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TelevisionSupplierType televisionSupplierType = db.TelevisionSupplierTypes.Find(id);
            db.TelevisionSupplierTypes.Remove(televisionSupplierType);
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
