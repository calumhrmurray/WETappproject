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
    public class AttitudesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Attitudes
        public ActionResult Index()
        {
            var attitudes = db.Attitudes.Include(a => a.Household);
            return View(attitudes.ToList());
        }

        // GET: Attitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attitude attitude = db.Attitudes.Find(id);
            if (attitude == null)
            {
                return HttpNotFound();
            }
            return View(attitude);
        }

        // GET: Attitudes/Create
        public ActionResult Create(string returnUrl, string id)
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

        // POST: Attitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttitudeID,HouseholdID,WashingMachine,Dishwasher,WashingLow,DishwashLow,WashingEff,DishwasherEff,Kettle,TapsOff,WashingBowl,RinsingBowl,TapsFlow,NoKitchen,OtherKitchen,NoFlush,LowFlush,CDD,LowShower,TapsOffBrush,ShowersNotBaths,LessBathWater,ShorterShowers,TapsFlowBath,NoBathroom,OtherBath,WaterButt,WaterCan,NoHosepipe,NoWaterLawn,NoGarden,OtherGarden,UpdateDate")] Attitude attitude, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.Attitudes.Add(attitude);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", attitude.HouseholdID);
            return View(attitude);
        }

        // GET: Attitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attitude attitude = db.Attitudes.Find(id);
            if (attitude == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", attitude.HouseholdID);
            return View(attitude);
        }

        // POST: Attitudes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttitudeID,HouseholdID,WashingMachine,Dishwasher,WashingLow,DishwashLow,WashingEff,DishwasherEff,Kettle,TapsOff,WashingBowl,RinsingBowl,TapsFlow,NoKitchen,OtherKitchen,NoFlush,LowFlush,CDD,LowShower,TapsOffBrush,ShowersNotBaths,LessBathWater,ShorterShowers,TapsFlowBath,NoBathroom,OtherBath,WaterButt,WaterCan,NoHosepipe,NoWaterLawn,NoGarden,OtherGarden,UpdateDate")] Attitude attitude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attitude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", attitude.HouseholdID);
            return View(attitude);
        }

        // GET: Attitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attitude attitude = db.Attitudes.Find(id);
            if (attitude == null)
            {
                return HttpNotFound();
            }
            return View(attitude);
        }

        // POST: Attitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attitude attitude = db.Attitudes.Find(id);
            db.Attitudes.Remove(attitude);
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
