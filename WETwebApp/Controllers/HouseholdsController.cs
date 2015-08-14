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
    public class HouseholdsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Households
        public ActionResult Index()
        {
            var households = db.Households.Include(h => h.Developer).Include(h => h.HouseholdType);
            return View(households.ToList());
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperID = new SelectList(db.Developers, "DeveloperID", "Type");
            ViewBag.HouseholdTypeID = new SelectList(db.HouseholdTypes, "HouseholdTypeID", "Type");
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdID,HouseholdTypeID,DeveloperID,WPnumber,Address1,Address2,Town,Postcode,HESarea,HESbatch,MonitorStatus,FirstReading")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Households.Add(household);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperID = new SelectList(db.Developers, "DeveloperID", "Type", household.DeveloperID);
            ViewBag.HouseholdTypeID = new SelectList(db.HouseholdTypes, "HouseholdTypeID", "Type", household.HouseholdTypeID);
            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperID = new SelectList(db.Developers, "DeveloperID", "Type", household.DeveloperID);
            ViewBag.HouseholdTypeID = new SelectList(db.HouseholdTypes, "HouseholdTypeID", "Type", household.HouseholdTypeID);
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdID,HouseholdTypeID,DeveloperID,WPnumber,Address1,Address2,Town,Postcode,HESarea,HESbatch,MonitorStatus,FirstReading")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperID = new SelectList(db.Developers, "DeveloperID", "Type", household.DeveloperID);
            ViewBag.HouseholdTypeID = new SelectList(db.HouseholdTypes, "HouseholdTypeID", "Type", household.HouseholdTypeID);
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
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
