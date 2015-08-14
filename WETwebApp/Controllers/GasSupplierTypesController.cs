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
    public class GasSupplierTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: GasSupplierTypes
        public ActionResult Index()
        {
            return View(db.GasSupplierTypes.ToList());
        }

        // GET: GasSupplierTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasSupplierType gasSupplierType = db.GasSupplierTypes.Find(id);
            if (gasSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(gasSupplierType);
        }

        // GET: GasSupplierTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasSupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GasSupplierTypeID,Type")] GasSupplierType gasSupplierType)
        {
            if (ModelState.IsValid)
            {
                db.GasSupplierTypes.Add(gasSupplierType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasSupplierType);
        }

        // GET: GasSupplierTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasSupplierType gasSupplierType = db.GasSupplierTypes.Find(id);
            if (gasSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(gasSupplierType);
        }

        // POST: GasSupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GasSupplierTypeID,Type")] GasSupplierType gasSupplierType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasSupplierType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasSupplierType);
        }

        // GET: GasSupplierTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasSupplierType gasSupplierType = db.GasSupplierTypes.Find(id);
            if (gasSupplierType == null)
            {
                return HttpNotFound();
            }
            return View(gasSupplierType);
        }

        // POST: GasSupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasSupplierType gasSupplierType = db.GasSupplierTypes.Find(id);
            db.GasSupplierTypes.Remove(gasSupplierType);
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
