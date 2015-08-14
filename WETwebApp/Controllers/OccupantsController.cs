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
    public class OccupantsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Occupants
        public ActionResult Index()
        {
            var occupants = db.Occupants.Include(o => o.Household);
            return View(occupants.ToList());
        }

        // GET: Occupants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupant occupant = db.Occupants.Find(id);
            if (occupant == null)
            {
                return HttpNotFound();
            }
            return View(occupant);
        }

        // GET: Occupants/Create
        public ActionResult Create(string id, string returnUrl)
        {
            string searchString = id;

            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.HouseholdID = new SelectList(db.Households.Where(s => s.WPnumber.Contains(searchString)), "HouseholdID", "WPnumber");
            }

            return View();
        }

        // POST: Occupants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OccupantID,HouseholdID,MaleQuantity,FemaleQuantity,ChildQuantity,OccupantNotes,SelfEmployed,EmployedFull,EmployedPart,Home,Retired,Unemployed,School,Further,GovWork,PreSchool,Other,DemographicNotes,BedroomQuantity,UpdateDate")] Occupant occupant, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Occupants.Add(occupant);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", occupant.HouseholdID);
            return View(occupant);
        }

        // GET: Occupants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupant occupant = db.Occupants.Find(id);
            if (occupant == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", occupant.HouseholdID);
            return View(occupant);
        }

        // POST: Occupants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OccupantID,HouseholdID,MaleQuantity,FemaleQuantity,ChildQuantity,OccupantNotes,SelfEmployed,EmployedFull,EmployedPart,Home,Retired,Unemployed,School,Further,GovWork,PreSchool,Other,DemographicNotes,BedroomQuantity,UpdateDate")] Occupant occupant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", occupant.HouseholdID);
            return View(occupant);
        }

        // GET: Occupants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupant occupant = db.Occupants.Find(id);
            if (occupant == null)
            {
                return HttpNotFound();
            }
            return View(occupant);
        }

        // POST: Occupants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occupant occupant = db.Occupants.Find(id);
            db.Occupants.Remove(occupant);
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
