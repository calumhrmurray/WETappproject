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
    public class WaterUnderstandingsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: WaterUnderstandings
        public ActionResult Index()
        {
            var waterUnderstanding = db.WaterUnderstanding.Include(w => w.Household).Include(w => w.WaterReduction);
            return View(waterUnderstanding.ToList());
        }

        // GET: WaterUnderstandings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterUnderstanding waterUnderstanding = db.WaterUnderstanding.Find(id);
            if (waterUnderstanding == null)
            {
                return HttpNotFound();
            }
            return View(waterUnderstanding);
        }

        // GET: WaterUnderstandings/Create
        public ActionResult Create(string returnUrl, string id)
        {
            string searchString = id;

            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");
            ViewBag.WaterReductionID = new SelectList(db.WaterReductions, "WaterReductionID", "Type");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.HouseholdID = new SelectList(db.Households.Where(s => s.WPnumber.Contains(searchString)), "HouseholdID", "WPnumber");
            }

            return View();
        }

        // POST: WaterUnderstandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WaterUnderstandingID,HouseholdID,WaterReductionID,WaterSupplier,FamilyUsage,IndividualUsage,SavingBills,WaterReductionWhy,UpdateDate")] WaterUnderstanding waterUnderstanding, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.WaterUnderstanding.Add(waterUnderstanding);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", waterUnderstanding.HouseholdID);
            ViewBag.WaterReductionID = new SelectList(db.WaterReductions, "WaterReductionID", "Type", waterUnderstanding.WaterReductionID);
            return View(waterUnderstanding);
        }

        // GET: WaterUnderstandings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterUnderstanding waterUnderstanding = db.WaterUnderstanding.Find(id);
            if (waterUnderstanding == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", waterUnderstanding.HouseholdID);
            ViewBag.WaterReductionID = new SelectList(db.WaterReductions, "WaterReductionID", "Type", waterUnderstanding.WaterReductionID);
            return View(waterUnderstanding);
        }

        // POST: WaterUnderstandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WaterUnderstandingID,HouseholdID,WaterReductionID,WaterSupplier,FamilyUsage,IndividualUsage,SavingBills,WaterReductionWhy,UpdateDate")] WaterUnderstanding waterUnderstanding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterUnderstanding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", waterUnderstanding.HouseholdID);
            ViewBag.WaterReductionID = new SelectList(db.WaterReductions, "WaterReductionID", "Type", waterUnderstanding.WaterReductionID);
            return View(waterUnderstanding);
        }

        // GET: WaterUnderstandings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterUnderstanding waterUnderstanding = db.WaterUnderstanding.Find(id);
            if (waterUnderstanding == null)
            {
                return HttpNotFound();
            }
            return View(waterUnderstanding);
        }

        // POST: WaterUnderstandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterUnderstanding waterUnderstanding = db.WaterUnderstanding.Find(id);
            db.WaterUnderstanding.Remove(waterUnderstanding);
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
