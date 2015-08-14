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
    public class HouseholdTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: HouseholdTypes
        public ActionResult Index()
        {
            return View(db.HouseholdTypes.ToList());
        }

        // GET: HouseholdTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdType householdType = db.HouseholdTypes.Find(id);
            if (householdType == null)
            {
                return HttpNotFound();
            }
            return View(householdType);
        }

        // GET: HouseholdTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseholdTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdTypeID,Type")] HouseholdType householdType)
        {
            if (ModelState.IsValid)
            {
                db.HouseholdTypes.Add(householdType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(householdType);
        }

        // GET: HouseholdTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdType householdType = db.HouseholdTypes.Find(id);
            if (householdType == null)
            {
                return HttpNotFound();
            }
            return View(householdType);
        }

        // POST: HouseholdTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdTypeID,Type")] HouseholdType householdType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(householdType);
        }

        // GET: HouseholdTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdType householdType = db.HouseholdTypes.Find(id);
            if (householdType == null)
            {
                return HttpNotFound();
            }
            return View(householdType);
        }

        // POST: HouseholdTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdType householdType = db.HouseholdTypes.Find(id);
            db.HouseholdTypes.Remove(householdType);
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
