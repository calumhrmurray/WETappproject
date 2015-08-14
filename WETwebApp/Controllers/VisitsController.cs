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
    public class VisitsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Visits
        public ActionResult Index(string id)
        {
            string searchString = id;
            
            var visits = db.Visits.Include(v => v.Household).Include(v => v.VisitType);

            if (!String.IsNullOrEmpty(searchString))
            {
                visits = visits.Where(v => v.Household.WPnumber == searchString);
            }

            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitID,HouseholdID,VisitTypeID,Complete,VisitDate")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", visit.HouseholdID);
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type", visit.VisitTypeID);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", visit.HouseholdID);
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type", visit.VisitTypeID);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitID,HouseholdID,VisitTypeID,Complete,VisitDate")] Visit visit, Household household, string wpNumber)
        {

            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Management", "Navigation");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", visit.HouseholdID);
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type", visit.VisitTypeID);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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

        // Complete is identical to edit it's just from a different path and to a different place
        // GET: Visits/Complete/5
        public ActionResult Complete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", visit.HouseholdID);
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type", visit.VisitTypeID);
            return View(visit);
        }

        // POST: Visits/Complete/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete([Bind(Include = "VisitID,HouseholdID,VisitTypeID,Complete,VisitDate")] Visit visit, Household household, string wpNumber)
        {

            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Visits", "Navigation");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", visit.HouseholdID);
            ViewBag.VisitTypeID = new SelectList(db.VisitTypes, "VisitTypeID", "Type", visit.VisitTypeID);
            return View(visit);
        }


    }
}
