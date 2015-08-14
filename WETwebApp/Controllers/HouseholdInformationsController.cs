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
    public class HouseholdInformationsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: HouseholdInformations
        public ActionResult Index()
        {
            var householdInformation = db.HouseholdInformation.Include(h => h.ElectricitySupplierType).Include(h => h.GasSupplierType).Include(h => h.HeatingSystemType).Include(h => h.Household).Include(h => h.HouseholdDescriptionType).Include(h => h.TelevisionSupplierType);
            return View(householdInformation.ToList());
        }

        // GET: HouseholdInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInformation householdInformation = db.HouseholdInformation.Find(id);
            if (householdInformation == null)
            {
                return HttpNotFound();
            }
            return View(householdInformation);
        }

        // GET: HouseholdInformations/Create
        public ActionResult Create(string returnUrl, string id)
        {
            string searchString = id;

            ViewBag.returnUrl = Request.UrlReferrer.ToString();

            ViewBag.ElectricitySupplierTypeID = new SelectList(db.ElectricitySupplierTypes, "ElectricitySupplierTypeID", "Type");
            ViewBag.GasSupplierTypeID = new SelectList(db.GasSupplierTypes, "GasSupplierTypeID", "Type");
            ViewBag.HeatingSystemTypeID = new SelectList(db.HeatingSystemTypes, "HeatingSystemTypeID", "Type");
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");
            ViewBag.HouseholdDescriptionTypeID = new SelectList(db.HouseholdDescriptionTypes, "HouseholdDescriptionTypeID", "Type");
            ViewBag.TelevisionSupplierTypeID = new SelectList(db.TelevisionSupplierTypes, "TelevisionSupplierTypeID", "Type");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.HouseholdID = new SelectList(db.Households.Where(s => s.WPnumber.Contains(searchString)), "HouseholdID", "WPnumber");
            }

            return View();
        }

        // POST: HouseholdInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdInformationID,HouseholdID,ElectricitySupplierTypeID,GasSupplierTypeID,TelevisionSupplierTypeID,HeatingSystemTypeID,HouseholdDescriptionTypeID,InternetAccess,HouseholdNotes,UpdateDate")] HouseholdInformation householdInformation, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.HouseholdInformation.Add(householdInformation);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.ElectricitySupplierTypeID = new SelectList(db.ElectricitySupplierTypes, "ElectricitySupplierTypeID", "Type", householdInformation.ElectricitySupplierTypeID);
            ViewBag.GasSupplierTypeID = new SelectList(db.GasSupplierTypes, "GasSupplierTypeID", "Type", householdInformation.GasSupplierTypeID);
            ViewBag.HeatingSystemTypeID = new SelectList(db.HeatingSystemTypes, "HeatingSystemTypeID", "Type", householdInformation.HeatingSystemTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", householdInformation.HouseholdID);
            ViewBag.HouseholdDescriptionTypeID = new SelectList(db.HouseholdDescriptionTypes, "HouseholdDescriptionTypeID", "Type", householdInformation.HouseholdDescriptionTypeID);
            ViewBag.TelevisionSupplierTypeID = new SelectList(db.TelevisionSupplierTypes, "TelevisionSupplierTypeID", "Type", householdInformation.TelevisionSupplierTypeID);
            return View(householdInformation);
        }

        // GET: HouseholdInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInformation householdInformation = db.HouseholdInformation.Find(id);
            if (householdInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElectricitySupplierTypeID = new SelectList(db.ElectricitySupplierTypes, "ElectricitySupplierTypeID", "Type", householdInformation.ElectricitySupplierTypeID);
            ViewBag.GasSupplierTypeID = new SelectList(db.GasSupplierTypes, "GasSupplierTypeID", "Type", householdInformation.GasSupplierTypeID);
            ViewBag.HeatingSystemTypeID = new SelectList(db.HeatingSystemTypes, "HeatingSystemTypeID", "Type", householdInformation.HeatingSystemTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", householdInformation.HouseholdID);
            ViewBag.HouseholdDescriptionTypeID = new SelectList(db.HouseholdDescriptionTypes, "HouseholdDescriptionTypeID", "Type", householdInformation.HouseholdDescriptionTypeID);
            ViewBag.TelevisionSupplierTypeID = new SelectList(db.TelevisionSupplierTypes, "TelevisionSupplierTypeID", "Type", householdInformation.TelevisionSupplierTypeID);
            return View(householdInformation);
        }

        // POST: HouseholdInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdInformationID,HouseholdID,ElectricitySupplierTypeID,GasSupplierTypeID,TelevisionSupplierTypeID,HeatingSystemTypeID,HouseholdDescriptionTypeID,InternetAccess,HouseholdNotes,UpdateDate")] HouseholdInformation householdInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElectricitySupplierTypeID = new SelectList(db.ElectricitySupplierTypes, "ElectricitySupplierTypeID", "Type", householdInformation.ElectricitySupplierTypeID);
            ViewBag.GasSupplierTypeID = new SelectList(db.GasSupplierTypes, "GasSupplierTypeID", "Type", householdInformation.GasSupplierTypeID);
            ViewBag.HeatingSystemTypeID = new SelectList(db.HeatingSystemTypes, "HeatingSystemTypeID", "Type", householdInformation.HeatingSystemTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", householdInformation.HouseholdID);
            ViewBag.HouseholdDescriptionTypeID = new SelectList(db.HouseholdDescriptionTypes, "HouseholdDescriptionTypeID", "Type", householdInformation.HouseholdDescriptionTypeID);
            ViewBag.TelevisionSupplierTypeID = new SelectList(db.TelevisionSupplierTypes, "TelevisionSupplierTypeID", "Type", householdInformation.TelevisionSupplierTypeID);
            return View(householdInformation);
        }

        // GET: HouseholdInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInformation householdInformation = db.HouseholdInformation.Find(id);
            if (householdInformation == null)
            {
                return HttpNotFound();
            }
            return View(householdInformation);
        }

        // POST: HouseholdInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdInformation householdInformation = db.HouseholdInformation.Find(id);
            db.HouseholdInformation.Remove(householdInformation);
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
