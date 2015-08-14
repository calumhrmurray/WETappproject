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
    public class BathroomsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Bathrooms
        public ActionResult Index()
        {
            var bathrooms = db.Bathrooms.Include(b => b.BathroomType).Include(b => b.Household);
            return View(bathrooms.ToList());
        }

        // GET: Bathrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            return View(bathroom);
        }

        // GET: Bathrooms/Create
        public ActionResult Create(string id, string returnUrl)
        {
            string searchString = id;

            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            ViewBag.BathroomTypeID = new SelectList(db.BathroomTypes, "BathroomTypeID", "Type");
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.HouseholdID = new SelectList(db.Households.Where(s => s.WPnumber.Contains(searchString)), "HouseholdID", "WPnumber");
            }

            return View();
        }

        // POST: Bathrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BathroomID,HouseholdID,BathroomTypeID,BathroomQuantity,ToiletQuantity,SingleToiletQuantity,DualToiletQuantity,Electric,Power,Mixer,Unknown,Round,Threaded,NonThreaded,Other,UpdateDate")] Bathroom bathroom, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.Bathrooms.Add(bathroom);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.BathroomTypeID = new SelectList(db.BathroomTypes, "BathroomTypeID", "Type", bathroom.BathroomTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", bathroom.HouseholdID);
            return View(bathroom);
        }

        // GET: Bathrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.BathroomTypeID = new SelectList(db.BathroomTypes, "BathroomTypeID", "Type", bathroom.BathroomTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", bathroom.HouseholdID);
            return View(bathroom);
        }

        // POST: Bathrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BathroomID,HouseholdID,BathroomTypeID,BathroomQuantity,ToiletQuantity,SingleToiletQuantity,DualToiletQuantity,Electric,Power,Mixer,Unknown,Round,Threaded,NonThreaded,Other,UpdateDate")] Bathroom bathroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bathroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BathroomTypeID = new SelectList(db.BathroomTypes, "BathroomTypeID", "Type", bathroom.BathroomTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", bathroom.HouseholdID);
            return View(bathroom);
        }

        // GET: Bathrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            return View(bathroom);
        }

        // POST: Bathrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bathroom bathroom = db.Bathrooms.Find(id);
            db.Bathrooms.Remove(bathroom);
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
