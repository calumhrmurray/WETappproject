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
    public class KitchensController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Kitchens
        public ActionResult Index()
        {
            var kitchens = db.Kitchens.Include(k => k.Household);
            return View(kitchens.ToList());
        }

        // GET: Kitchens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        // GET: Kitchens/Create
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

        // POST: Kitchens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KitchenID,HouseholdID,WashingMachine,Dishwasher,UpdateDate")] Kitchen kitchen, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Kitchens.Add(kitchen);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", kitchen.HouseholdID);
            return View(kitchen);
        }

        // GET: Kitchens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", kitchen.HouseholdID);
            return View(kitchen);
        }

        // POST: Kitchens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KitchenID,HouseholdID,WashingMachine,Dishwasher,UpdateDate")] Kitchen kitchen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitchen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", kitchen.HouseholdID);
            return View(kitchen);
        }

        // GET: Kitchens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        // POST: Kitchens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitchen kitchen = db.Kitchens.Find(id);
            db.Kitchens.Remove(kitchen);
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
