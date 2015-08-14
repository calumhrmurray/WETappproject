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
    public class OutdoorsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Outdoors
        public ActionResult Index()
        {
            var outdoors = db.Outdoors.Include(o => o.Household);
            return View(outdoors.ToList());
        }

        // GET: Outdoors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outdoor outdoor = db.Outdoors.Find(id);
            if (outdoor == null)
            {
                return HttpNotFound();
            }
            return View(outdoor);
        }

        // GET: Outdoors/Create
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

        // POST: Outdoors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutdoorID,HouseholdID,Garden,Car,WaterGarden,WashCar,UpdateDate")] Outdoor outdoor, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.Outdoors.Add(outdoor);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", outdoor.HouseholdID);
            return View(outdoor);
        }

        // GET: Outdoors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outdoor outdoor = db.Outdoors.Find(id);
            if (outdoor == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", outdoor.HouseholdID);
            return View(outdoor);
        }

        // POST: Outdoors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutdoorID,HouseholdID,Garden,Car,WaterGarden,WashCar,UpdateDate")] Outdoor outdoor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outdoor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", outdoor.HouseholdID);
            return View(outdoor);
        }

        // GET: Outdoors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outdoor outdoor = db.Outdoors.Find(id);
            if (outdoor == null)
            {
                return HttpNotFound();
            }
            return View(outdoor);
        }

        // POST: Outdoors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outdoor outdoor = db.Outdoors.Find(id);
            db.Outdoors.Remove(outdoor);
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
