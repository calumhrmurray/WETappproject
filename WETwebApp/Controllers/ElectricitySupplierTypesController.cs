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
    public class ElectricitySupplierTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: ElectricitySupplierTypes
        public ActionResult Index()
        {
            return View(db.ElectricitySupplierTypes.ToList());
        }

        // GET: ElectricitySupplierTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricitySupplierType electricitySupplierType = db.ElectricitySupplierTypes.Find(id);
            if (electricitySupplierType == null)
            {
                return HttpNotFound();
            }
            return View(electricitySupplierType);
        }

        // GET: ElectricitySupplierTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectricitySupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElectricitySupplierTypeID,Type")] ElectricitySupplierType electricitySupplierType)
        {
            if (ModelState.IsValid)
            {
                db.ElectricitySupplierTypes.Add(electricitySupplierType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(electricitySupplierType);
        }

        // GET: ElectricitySupplierTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricitySupplierType electricitySupplierType = db.ElectricitySupplierTypes.Find(id);
            if (electricitySupplierType == null)
            {
                return HttpNotFound();
            }
            return View(electricitySupplierType);
        }

        // POST: ElectricitySupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElectricitySupplierTypeID,Type")] ElectricitySupplierType electricitySupplierType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricitySupplierType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electricitySupplierType);
        }

        // GET: ElectricitySupplierTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricitySupplierType electricitySupplierType = db.ElectricitySupplierTypes.Find(id);
            if (electricitySupplierType == null)
            {
                return HttpNotFound();
            }
            return View(electricitySupplierType);
        }

        // POST: ElectricitySupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElectricitySupplierType electricitySupplierType = db.ElectricitySupplierTypes.Find(id);
            db.ElectricitySupplierTypes.Remove(electricitySupplierType);
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
